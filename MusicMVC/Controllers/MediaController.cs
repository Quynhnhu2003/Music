using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMVC.Data;
using MusicMVC.ViewModels;

namespace MusicMVC.Controllers
{
    public class MediaController : Controller
    {
        private readonly MusicDbContext _context;
        public MediaController(MusicDbContext context)
        {
            _context = context;
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
    }
}
