using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sakuri.Areas.Identity.Data;
namespace Sakuri
{
    public class SakuriContext : IdentityDbContext<ApplicationUser>
    {
        public SakuriContext(DbContextOptions<SakuriContext> options) : base(options)
        { }
        
        public DbSet<Users> Users { get; set;}
        
        public DbSet<Items> Items { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=sakuridb;User Id=scouri;Password=K3qingWaifu");
    
    }
    [Table("items", Schema = "public")]
    public class Items
    {
        [Key]
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public DateOnly Time { get; set; }
        public string ItemCategory { get; set; }
        public virtual ApplicationUser ApplicationUser {get; set;}
    }
    [Table("users", Schema = "public")]
    public class Users
    {
        [Key]
        public long userid { get; set; }
        public List<Items> items {get;set;}
    } 
    
}
