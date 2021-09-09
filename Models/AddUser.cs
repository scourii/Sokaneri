using System.ComponentModel.DataAnnotations;

namespace Sakuri.Models
{
    public class AddUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Please enter a password with more than 10 characters.")]
        public string Password { get; set; }
    }
}
