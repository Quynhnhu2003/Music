using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMVC.Commons;
using MusicMVC.Data;
using MusicMVC.Data.Entities;
using MusicMVC.Enums;

namespace MusicMVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly MusicDbContext _context;

        public BaseController(IWebHostEnvironment environment, MusicDbContext context)
        {
            _context = context;
            _environment = environment;
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        this.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}

        protected async Task<Medium> SaveMedia(IFormFile? file)
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
