using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class VerificationCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime ExpireDate { get; set; }
        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }

        public int SellerId { get; set; }
        public virtual Sellers Seller { get; set; }
    }
}
