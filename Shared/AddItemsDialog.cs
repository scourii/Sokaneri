using System;  
using System.ComponentModel.DataAnnotations;  
using System.ComponentModel.DataAnnotations.Schema;  
namespace Sakuri.Shared
{
    [Table("Item")]  
    public partial class Item {  
        public int ItemId {  
            get;  
            set;  
        }  
        [Required]  
        [StringLength(50, ErrorMessage = "Item name is too long.")]  
        public string ItemName {  
            get;  
            set;  
        }  
        [Required]  
        [StringLength(50, ErrorMessage = "Category is too long.")]  
        public string Category {  
            get;  
            set;  
        }  
        [Required]  
        [EmailAddress]  
        public string Date {  
            get;  
            set;  
        }  
        public string Price {  
            get;  
            set;  
        }   
    }  
}
