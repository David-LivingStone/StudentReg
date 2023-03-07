using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentReg.Models
{
    public class Registration
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string Lastname { get; set; }
        [Required]
        [DisplayName("Other Names")]
        public string Othernames { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        public string Level { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


    }
}
