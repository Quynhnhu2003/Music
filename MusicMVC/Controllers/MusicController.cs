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
    public class MusicController : Controller
    {
        private readonly MusicDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public MusicController(MusicDbContext context, IWebHostEnvironment environment)
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
                    //var artist = music.Artist;
                    //if (artist != null)
                    //{
                    //    artist.MusicCount -= 1;
                    //}
                    //var listArtist = await _context.Artists
                    //    .Include(a => a.Musics)
                    //    .Where(a => a.Musics.Any(mbox => mbox.Id == idMusic))
                    //    .ToListAsync();
                    //if(listArtist != null && listArtist.Count > 0)
                    //{
                    //    foreach (var artist in listArtist)
                    //    {
                    //        artist.MusicCount -= 1;
                    //    }
                    //}
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
        public IActionResult ReloadMusicList()
        {

            return ViewComponent(nameof(MusicList));
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
        private async Task<Medium> SaveMedia(IFormFile? file)
        {
            bool isOk = false;
            if (file == null || file.Length == 0) return null;
            var fileGuidName = Guid.NewGuid().ToString();
            var fileName = "";
            var fileExtension = "";
            var fileNameString = file.FileName;
            //if( fileNameString != null )
            if (string.IsNullOrEmpty(fileNameString))
            {
                return null;
            }
            try
            {

                string[] arrayExtension = fileNameString.Split('.');
                var fullFileName = "";
                if (arrayExtension != null && arrayExtension.Length > 0)
                {
                    for (int i = 0; i < arrayExtension.Length; i++)
                    {
                        var ext = arrayExtension[i];
                        if (Constants.Invalid_Extenstion.Contains(ext))
                        {
                            return null;
                        }
                    }
                    fileName = arrayExtension[0];
                    fileExtension = arrayExtension[arrayExtension.Length - 1];
                    // Kiểm tra xem file có hợp lệ hay không
                    if (!Constants.Valid_Audio_Extenstion.Contains(fileExtension))
                    {
                        return null;
                    }
                    fullFileName = fileGuidName + "." + fileExtension;
                }
                var webRoot = _environment.WebRootPath.Normalize();
                //var webRoot2 = _environment.ContentRootPath.Normalize();
                var physicalMusicPath = Path.Combine(webRoot, "music/");
                if (!Directory.Exists(physicalMusicPath))
                {
                    Directory.CreateDirectory(physicalMusicPath);
                }
                var physicalPath = Path.Combine(physicalMusicPath, fullFileName);
                using (var stream = System.IO.File.Create(physicalPath))
                {
                    await file.CopyToAsync(stream);
                }
                // === Tạo media ===//
                var count = await _context.Media.CountAsync();
                var newMedium = new Medium
                {
                    Name = fileName,//Tên tìm kiếm
                    FileName = fileGuidName,// Tên lưu trữ
                    Extension = fileExtension,
                    Type = MediaTypeEnum.Audio,
                    Position = count + 1,
                };
                _context.Media.Add(newMedium);
                isOk = true;
                return newMedium;
            }
            catch
            {
            }
            return null;
        }
    }
}
