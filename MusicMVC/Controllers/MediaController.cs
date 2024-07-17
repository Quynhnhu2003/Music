using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMVC.Data;
using MusicMVC.ViewModels;
using System;

namespace MusicMVC.Controllers
{
    public class MediaController : BaseController
    {
        private readonly IWebHostEnvironment _environment;
        private readonly MusicDbContext _context;
        public MediaController(MusicDbContext context, IWebHostEnvironment environment)
            :base(environment, context)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<IActionResult> Index()
        {
            var arrayMedia = await _context.Media
                .OrderBy(x => x.Position)
                .Select(m => new MediumViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    FilePath = m.FileName + "." + m.Extension,
                    Position = m.Position,
                })
                .ToArrayAsync();
            return View();
        }
        public IActionResult Create()
        {
            var model = new List<IFormFile>();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadMedia(IList<IFormFile> listFile)
        {
            var status = false;
            var message = "Chưa thực thi";
            if (listFile != null && listFile.Count > 0)
            {
                try
                {
                    foreach (var file in listFile)
                    {
                        if (file.Length > 0)
                        {
                            //=== Xử lý file ===//
                            var media = await SaveMedia(file);
                            if (media == null) {
                                message = "File không hợp lệ!!!";
                                return Json(new { status, message });
                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                    status = true;
                    message = "Success";
                }
                catch
                {

                    status = false;
                    message = "Fail";
                }
                
            }
            return Json(new { status, message });
        }
    }
}
