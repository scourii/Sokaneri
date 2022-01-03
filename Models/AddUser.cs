using System.ComponentModel.DataAnnotations;

namespace Sakuri.Models
{
    public class AddUser
    {
        [Required]
        public long userid {get; set;}
        [Required]
        [MinLength(10, ErrorMessage = "Please enter a password with more than 10 characters.")]
        public string password { get; set; }
    }
}
