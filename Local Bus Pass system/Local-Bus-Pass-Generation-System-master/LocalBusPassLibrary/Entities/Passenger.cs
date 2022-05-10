using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBussPassLibrary.Entities
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be between 2-50 characters")]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Address should be between 10-100 characters")]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        [RegularExpression(@"[\d]{12}$", ErrorMessage = "Aadhar Number should be 12 digit ")]
        public string AadharId { get; set; }

        [Required]
        [RegularExpression(@"[\d]{10}$", ErrorMessage = "Mobile Number should be 10 digit")]
        public string MobileNo { get; set; }

        [Required]
        [RegularExpression(@"[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%?&])[A-Za-z\d@$!%?&]{8,16}$",
            ErrorMessage = "Please enter valid password")]

        public string Password { get; set; }

    }
}
