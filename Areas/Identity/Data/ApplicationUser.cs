using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sakuri.Areas.Identity.Data
{

    public class ApplicationUser : IdentityUser
    {
        
        [Key]
        [PersonalData]
        [Column(TypeName = "bigint")]
        public long userid { get; set; }
        public virtual ICollection<Items> Items {get; set;}
    }
}
