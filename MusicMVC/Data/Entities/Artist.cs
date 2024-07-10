using MusicMVC.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MusicMVC.Data.Entities
{
    public class Artist
    {
        public Artist() 
        {
            Id = Guid.NewGuid();
            Gender = GenderTypeEnum.Unknown;
            Musics = new Collection<Music>(); //navigational
        }

        public Guid Id { get; set; }
        [Description("Tên thật ca sĩ")]
        public string Name { get; set; }// kiểu string phải làm max length
        [Description("Nghệ danh ca sĩ")]
        public string Nickname { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public int MusicCount{ get; set; }
        public DateTime? DateOfBirth{ get; set; }
        public int Position { get; set; }
        public virtual ICollection<Music> Musics { get; set; }

    }
}
