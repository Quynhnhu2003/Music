using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMVC.Commons;
using MusicMVC.Data;
using MusicMVC.Data.Entities;
using MusicMVC.ViewModels;

namespace MusicMVC.ViewComponents
{
    public class MusicList : ViewComponent
    {
        private readonly MusicDbContext _context;
        public MusicList(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int currentPage = 1) //Nếu không có thông số sẽ nhận 1 là giá trị mặc định
        {
            //để lấy dữ liệu ra từ Be đến Fe thì dùng ViewBag
            ViewBag.CurrentPage = currentPage;

            var take = Constants.TAKE;
            var skip = (currentPage - 1) * take;

            var musicList = await _context.Musics
                 .Include(m => m.Artist)
                 .ToListAsync();
            if (musicList != null && musicList.Count > 0)
            {
                var tempNumber = musicList.Count / take;
                ViewBag.MaxPage = (musicList.Count % take == 0) ? tempNumber : tempNumber + 1;
            };

			var item = musicList
				.OrderBy(m => m.Position)
                .Select(m => new MusicSummaryViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    ArtistName = m.Artist.Name,
                    Position = m.Position,
                })
                .Skip(skip) //hàm Skip của Linq dùng để tính phần tử bỏ qua
                .Take(take) // hàm Take của Linq dùng để tính số phần tử cần lấy cho mỗi trang
                .ToList();
            return View(item);
        }

        private Task<List<Music>> GetItemsAsync()
        {
            return _context.Musics.ToListAsync();
        }
    }
}
