using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
