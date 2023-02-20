using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalConsole.Domain
{
    public class Appuser
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
        [MaxLength(25)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string password { get; set; }
        public bool Isadmin { get; set; }
    }
}
