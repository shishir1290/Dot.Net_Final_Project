using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        
        public string TokenString { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
    }
}
