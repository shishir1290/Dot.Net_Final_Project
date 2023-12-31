using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        public virtual ICollection<Products> Product { get; set; }
        public virtual ICollection<Buyer> Buyer { get; set; }

        public Cart()
        {
            Product = new List<Products>();
            Buyer = new List<Buyer>();
        }
    }
}
