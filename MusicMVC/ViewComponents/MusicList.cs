using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMVC.Data;
using MusicMVC.Data.Entities;

namespace MusicMVC.ViewComponents
{
    public class MusicList : ViewComponent
    {
        private readonly MusicDbContext _context;
        public MusicList(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var item = await GetItemsAsync();
            var item = await _context.Musics
                .Include(m => m.Artist)
                .OrderBy(m => m.Position)
                .ToListAsync();
            return View(item);
        }

        private Task<List<Music>> GetItemsAsync()
        {
            return _context.Musics.ToListAsync();
        }
    }
}
