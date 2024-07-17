using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace MusicMVC.Data.Entities
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            OrderDetails = new Collection<OrderDetail>();
        }
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }

        // List of Products
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
