using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string BuyerId { get; set; }
        public string SellerId { get; set; }

    }
}
