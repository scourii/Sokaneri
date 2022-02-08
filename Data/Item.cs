using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sakuri.Data
{
    [Table("items", Schema = "public")]
    public class Item
    {
        [Required]
        public String itemname;
        [Required]
        public int itemprice;
        public string itemcategory;
        [Required]
        public DateOnly itemdate;
    }
}
