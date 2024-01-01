using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Model
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "BuyerId is required.")]
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }

        [Required(ErrorMessage = "ProductIds is required.")]
        public int[] ProductIds { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "TotalPrice is required.")]
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "OrderDate is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        public virtual ICollection<Buyer> Buyer { get; set; }
        public virtual ICollection<Products> Products { get; set; }

        public Order()
        {
            Buyer = new List<Buyer>();
            Products = new List<Products>();
        }
    }
}
