using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBussPassLibrary.Entities
{
    public class AdminDetails
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The FirstName must be between 2-50 characters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Value of email is not correct format")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%?&])[A-Za-z\d@$!%?&]{8,16}$",
            ErrorMessage = "Password must contain atleast one UpperCase, one Lowercase, one Special character" +
                ",one Numerical value. Length must be between (8-16)")]
        public string Password { get; set; }

    }
}
