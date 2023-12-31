using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }

        public virtual ICollection<Buyer> Buyer { get; set; }
        public virtual ICollection<Products> Product { get; set; }

        public Order()
        {
            Buyer = new List<Buyer>();
            Product = new List<Products>();
        }
    }
}
