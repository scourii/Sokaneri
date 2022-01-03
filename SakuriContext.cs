using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sakuri
{
    public class SakuriContext : DbContext
    {
        public SakuriContext(DbContextOptions<SakuriContext> options) : base(options)
        { }
        
        public DbSet<Users> Users { get; set;}
        public DbSet<MonthlyExpenses> MonthlyExpenses { get; set; }
        public DbSet<YearlyExpenses> YearlyExpenses { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=sakuridb;User Id=scouri;Password=K3qingWaifu");
    
    }
    public class MonthlyExpenses
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string Time { get; set; }
        public string ItemCategory { get; set; }
    }
    public class YearlyExpenses
    {
        [Key]
        public int Id {get; set;}
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string Time { get; set; }
        public string ItemCategory { get; set; }
    }
    [Table("users", Schema = "public")]
    public class Users
    {
        [Key]
        public long userid { get; set; }
        public string password { get; set;}
    }
    
}
