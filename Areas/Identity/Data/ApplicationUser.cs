using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Sakuri.Models;

namespace Sakuri.Areas.Identity.Data
{

    public class ApplicationUser : IdentityUser
    {
        public ICollection<Items> Items {get; set;}
    }
}
