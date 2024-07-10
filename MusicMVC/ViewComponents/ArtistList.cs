using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMVC.Data;
using MusicMVC.Data.Entities;

namespace MusicMVC.ViewComponents
{
    public class ArtistList : ViewComponent
    {
        private readonly MusicDbContext _context;
        public ArtistList(MusicDbContext context)
        {
            _context = context;
        }   

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await GetItemsAsync();
            return View(item);
        }

        private  Task<List<Artist>> GetItemsAsync()
        {
           return  _context.Artists
                .OrderBy(a => a.Position)
                .ToListAsync();
        }
    }
}
