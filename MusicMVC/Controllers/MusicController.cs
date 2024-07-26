using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicMVC.Commons;
using MusicMVC.Data;
using MusicMVC.Data.Entities;
using MusicMVC.Enums;
using MusicMVC.ViewComponents;
using MusicMVC.ViewModels;


namespace MusicMVC.Controllers
{
    [Authorize(Roles = "Manager, Editor")]
    public class MusicController : BaseController
    {
        private readonly IWebHostEnvironment _environment;
        private readonly MusicDbContext _context;
        public MusicController(MusicDbContext context, IWebHostEnvironment environment)
            : base(environment, context)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Create()
        {

            ViewBag.Artists = await GetArtistSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MusicViewModel musicVM)
        {
            try
            {
                var media = await SaveMedia(musicVM.FileMusic);

                var countMusic = await _context.Musics.CountAsync();
                var newMusic = new Data.Entities.Music
                {
                    Name = musicVM.Name.Trim(),
                    Lyrics = musicVM.Lyrics.Trim(),
                    Price = musicVM.Price,
                    PriceDiscounted = musicVM.PriceDiscounted,
                    ArtistId = musicVM.ArtistId,
                    //FileName = fileGuidName,
                    MediumId = media != null ? media.Id : null,
                    Position = countMusic + 1,

                };
                //newMusic.FileName = musicVM.Get(newMusic);

                _context.Musics.Add(newMusic);
                await UpdateMusicCountByArtist(musicVM.ArtistId, 1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));

            }
            catch
            {
                ViewBag.Artists = await GetArtistSelectList();
                return View(musicVM);
            }
        }

        // GET: MusicController/Edit/5
        public async Task<ActionResult> Edit(Guid idMusic)
        {
            // thêm await thì nhớ thêm async và task
            //var music = await _context.Musics.FindAsync(idMusic);
            var music = await _context.Musics
                .Where(m => m.Id.Equals(idMusic))
                .Include(m => m.Medium)
                .SingleOrDefaultAsync();
            if (music == null) return BadRequest();
            var musicVM = new MusicViewModel
            {
                Id = music.Id,
                Name = music.Name,
                Lyrics = music.Lyrics,
                Price = music.Price,
                PriceDiscounted = music.PriceDiscounted,
                ArtistId = music.ArtistId,
                //FileName = music.FileName,
                MusicPath = MusicViewModel.GetMusicPath(music),
            };
            ViewBag.Artists = await GetArtistSelectList();
            //return View("Create", music);
            return View(nameof(Create), musicVM);
        }

        // POST: ArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MusicViewModel musicVM)
        {
            try
            {
                //_context.Entry(music).State = EntityState.Modified;
                var music = await _context.Musics.FindAsync(musicVM.Id);
                if (music == null) { return BadRequest(); }
                //=== Sửa trường nào thì cập nhật trường đó ===//
                music.Name = musicVM.Name;
                music.Lyrics = musicVM.Lyrics;
                music.Price = musicVM.Price;
                music.PriceDiscounted = musicVM.PriceDiscounted;
                if (musicVM.ArtistId != music.ArtistId)
                {
                    await UpdateMusicCountByArtist(musicVM.ArtistId, 1);
                    await UpdateMusicCountByArtist(musicVM.ArtistId, -1);

                    music.ArtistId = musicVM.ArtistId;
                }
                if (musicVM.FileMusic != null)//
                {
                    //=== Update Media ===//
                    var media = await SaveMedia(musicVM.FileMusic);
                    if (media != null)
                    {
                        music.MediumId = media.Id;
                    }
                }
                await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
            }
            catch
            {
                ViewBag.Artists = await GetArtistSelectList();
                return View(nameof(Create), musicVM);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid idMusic)
        {
            var status = false;
            var message = "Chưa thực thi";
            try
            {
                //var music = await _context.Musics.FindAsync(idMusic);
                //=== Predicate/delgate ===//
                var music = await _context.Musics
                    .Where(m => m.Id.Equals(idMusic))
                    .Include(m => m.Artist)
                    .SingleOrDefaultAsync();
                if (music != null)
                {
                    //=== Step 1: Decreasement Position ===//
                    var currentPosition = music.Position;
                    var listMusic = await _context.Musics
                        .Where(x => x.Position > currentPosition)
                        .ToListAsync();
                    if(listMusic != null && listMusic.Count > 0)
                    {
                        foreach (var item in listMusic)
                        {
                            item.Position -= 1;
                        }
                    }
                    //=== Step 2: Recalculate MusicCount in Artist ===//
                    music.Artist.MusicCount -= 1;

                    //=== Step 3: Remove Music ====//
                    _context.Musics.Remove(music);
                }

                await _context.SaveChangesAsync();
                status = true;
                message = "Thành công";
            }
            catch
            {
                message = "Lỗi thực thi";
            }
            return Json(new {status, message });
        }
        public IActionResult ReloadMusicList(int currentPage = 1)
        {

            return ViewComponent(nameof(MusicList), new { currentPage });
        }
        private async Task<bool> UpdateMusicCountByArtist(Guid idArtist, int valueChanged)
        {
            var isOk = false;

            var artist = await _context.Artists.FindAsync(idArtist);
            if (artist != null)
            {
                artist.MusicCount += valueChanged;
            }
            return isOk;
        }
        private async Task<SelectList> GetArtistSelectList()
        {
            var listArtist = await _context.Artists
                .Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name,
                })
                .ToListAsync();
            return new SelectList(listArtist, "Id", "Name");
        }
        public async Task<IActionResult> ProductList()
        {
            var model = await _context.Musics
                .Include(m => m.Artist)
                .Include(m => m.Medium)
                .OrderBy(m => m.Position)
                .Select(m => new MusicViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Lyrics = m.Lyrics,
                    Position = m.Position,
                    Price = m.Price,
                    PriceDiscounted = m.PriceDiscounted,
                    //MusicPath = Constants.Music_Path + m.Medium.FileName = "." + m.Medium.Extension,
                    MusicPath = MusicViewModel.GetMusicPath(m),
                })
                .ToArrayAsync();

            return View(model);
        }
    }
}
