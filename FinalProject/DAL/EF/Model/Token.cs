using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public string TokenString { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public virtual ICollection<Buyer> Buyer { get; set; }
        public virtual ICollection<Sellers> Seller { get; set; }

    }
}
