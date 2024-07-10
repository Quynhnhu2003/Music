using MusicMVC.Enums;
using System.Collections.ObjectModel;

namespace MusicMVC.Data.Entities
{
    public class Medium
    {
        public Medium()
        {
            Id = Guid.NewGuid();
            Musics = new Collection<Music>();
        }
        public Guid Id {get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        // tên lưu trữ đã thay 
        public string FileName { get; set; }
        public string Extension { get; set; } //mp3, mp4
        public MediaTypeEnum Type { get; set; } //image, video clip,... 
        public int Position { get; set; }

        public virtual ICollection<Music> Musics { get; set; }
    }
}
