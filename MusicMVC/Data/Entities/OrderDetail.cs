using System.ComponentModel.DataAnnotations.Schema;

namespace MusicMVC.Data.Entities
{
    public class OrderDetail
    {
        public double Price { get; set; }
        public double PriceDiscounted { get; set; }
        public int Quantity { get; set; }
        public Decimal Amount { get; set; }
        public int Position { get; set; }

        //=== Navigational Property ===//
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        
        public Guid MusicId { get; set; }
        public virtual Music Music { get; set; }
    }
}
