using System.Collections.ObjectModel;

namespace MusicMVC.Data.Entities
{
    public class Music
    {
        public Music() 
        {
            this.Id = Guid.NewGuid();
            OrderDetails = new Collection<OrderDetail>();
        }

        // có thể đánh prop xong tab là xuất hiện bên dưới
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? FileName { get; set; }
        public string? Lyrics { get; set; }
        public int Position { get; set; }
/*        public int? ReleaseYear { get; set; } */

        // === Navigational Property === //
        public Guid ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public Guid? MediumId { get; set; }
        public virtual Medium Medium { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
