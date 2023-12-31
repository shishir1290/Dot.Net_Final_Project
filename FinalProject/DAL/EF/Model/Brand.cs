using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BrandName { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string BrandDescription { get; set; }
        
    }
}
