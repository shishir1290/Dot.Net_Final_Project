using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        [Required]
        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual Sellers Seller { get; set; }

       
    }
}
