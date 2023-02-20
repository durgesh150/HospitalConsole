using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsole.Domain
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
        [Required]
        [MaxLength(50)]
        public string HealthIssues { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        public DateTime CreatedOnDateTime { get; set; }
        [Required]
        public DateTime LastVisitDateTime { get; set; }
        [Required]
        public int CreatedByUserId { get; set; }
        [Required]
        public int UpdatedByUserId { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
