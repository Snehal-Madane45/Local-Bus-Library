using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBussPassLibrary.Entities
{
    public class PassDetails
    {
        [Key]
        public int PassId { get; set; }
        public Passenger Passenger { get; set; }
        [Required]
        public string PassType { get; set; }
        [Required]
        public int PassDuration { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }

        public DateTime ExpiryDate { get; set; }
        public float Amount { get; set; }
        [Required]
        public string PaymentMode { get; set; }
        [Required]
        public string PaymentStatus { get; set; }

    }
}
