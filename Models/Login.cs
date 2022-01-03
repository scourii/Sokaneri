using System.ComponentModel.DataAnnotations;

namespace Sakuri.Models
{
    public class Login
    {
        [Required]
        public long userid { get; set; }
        [Required]
        public string password { get; set; }
    }
}
