using System.ComponentModel.DataAnnotations;

namespace AfleveringM404.Models
{
    public class Contact
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
