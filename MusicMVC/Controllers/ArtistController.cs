using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMVC.Data;
using MusicMVC.Data.Entities;
using MusicMVC.ViewModels;
using System.Linq;

namespace MusicMVC.Controllers
{
    [Authorize(Roles = "Manager, Admin")]
    public class ArtistController : Controller
    {
        private readonly MusicDbContext _context;
        public ArtistController(MusicDbContext context) 
        {
            _context = context;
        }

        // GET: ArtistController/Create
        public ActionResult Create()
        {
            TempData.Keep();
            return View();
        }

        // POST: ArtistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArtistViewModel artistVM)
        {
            try
            {
                var countArtist = await _context.Artists.CountAsync();
                var newArtist = new Artist
                {
                    Name = artistVM.Name.Trim(),
                    Nickname = artistVM.Nickname?.Trim(),
                    Gender = artistVM.Gender,
                    DateOfBirth = artistVM.DateOfBirth,
                    MusicCount = 0,
                    Position = countArtist + 1,
                };
                _context.Artists.Add(newArtist);
                await _context.SaveChangesAsync();


                //ViewBag.Message = "Thêm Thành Công";
                TempData["Message"] = "Thêm Thành Công";
                //=== Lưu thành công thì quay về cho tạo tiếp ===//
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                TempData["Message"] = "Thêm Thất Bại";
                //=== Không thành công thì kiểm tra lại dữ liệu ===//
                return View(nameof(Create), artistVM);
                
            }
        }

        // GET: ArtistController/Edit/5
        public async Task<ActionResult> Edit(Guid idArtist)
        {
            // thêm await thì nhớ thêm async và task
            var artistVM = await _context.Artists
                .Where(a => a.Id.Equals(idArtist)) //trả về kiểu nguyên thủy equals
                .Select(a => new ArtistViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Nickname= a.Nickname,
                    Gender = a.Gender,
                    DateOfBirth = a.DateOfBirth,
                    //Position = a.Position,
                })
                .SingleOrDefaultAsync();
            if (artistVM == null) return BadRequest();

            return View(nameof(Create), artistVM);
        }

        // POST: ArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Artist artistVM)
        {
            try
            {
                var artist = await _context.Artists.FindAsync(artistVM.Id);
                if (artist ==null) return BadRequest();

                artist.Name = artistVM.Name.Trim();
                artist.Nickname = artistVM.Nickname.Trim();
                artist.Gender = artistVM.Gender;
                artist.DateOfBirth = artistVM.DateOfBirth;

                await _context.SaveChangesAsync();


                //ViewBag.Message = "Thêm Thành Công";
                TempData["Message"] = "Sửa Thành Công";
                //=== Lưu thành công thì quay về cho tạo tiếp ===//
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                TempData["Message"] = "Sửa Thất Bại";
                //=== Không thành công thì kiểm tra lại dữ liệu ===//
                return View(nameof(Create), artistVM);
            }
        }

        // GET: ArtistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
