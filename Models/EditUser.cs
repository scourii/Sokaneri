using System.ComponentModel.DataAnnotations;

namespace Sakuri.Models
{
    public class EditUser
    {
        [Required]
        public long userid { get; set; }
        [MinLength(10, ErrorMessage = "Please enter a password with more than 10 characters.")]
        public string Password { get; set; }
        public EditUser() { }
        public EditUser(User user)
        {
            Password = user.password;
        }
    }
}
