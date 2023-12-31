using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@gmail\.com$", ErrorMessage = "Email must be in the format sometings@gmail.com")]
        public string EmailAddress { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [Required, StringLength(1000)]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d.*\d)(?=.*\W.*\W)[A-Za-z\d\W]{8,}$",
            ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 2 symbols, 2 numbers, and be at least 8 characters long.")]
        public string Password { get; set; }

    }
}
