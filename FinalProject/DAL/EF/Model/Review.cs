using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string Reply { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ICollection<Buyer> Buyer { get; set; }
        public virtual ICollection<Products> Product { get; set; }

        public Review()
        {
            Date = DateTime.Now;
            Buyer = new List<Buyer>();
            Product = new List<Products>();
        }
    }
}
