using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Sellers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d.*\d)(?=.*\W.*\W)[A-Za-z\d\W]{6,}$",
            ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 2 symbols, 2 numbers, and be at least 6 characters long.")]
        public string Password { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
