using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sakuri.Data
{
    [Table("users", Schema = "public")]
    public class User
    {
        [Key]
        public long userid { get; set; }
        public string password {get; set;}
    }
}
