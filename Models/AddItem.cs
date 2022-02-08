using System.ComponentModel.DataAnnotations;
namespace Sakuri.Models
{
    public class AddItem
    {
        [Required]
        public String itemname;
        [Required]
        public int itemprice;
        public String itemcategory;
        [Required]
        public DateOnly itemdate;
    }
}
