using System.ComponentModel.DataAnnotations;
using Sakuri.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sakuri.Models
{
    public class Items
        {
            [Key]
            public string ItemName { get; set; }
            public int ItemPrice { get; set; }
            public DateOnly Time { get; set; }
            public string ItemCategory { get; set; }
            public string UserName { get; set;}
            [ForeignKey("UserName")]
            public virtual ApplicationUser ApplicationUser {get; set;}
        }
}
