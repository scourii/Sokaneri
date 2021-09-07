using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sakuri
{
    public class SakuriContext : DbContext
    {
        public SakuriContext(DbContextOptions<SakuriContext> options) : base(options)
        { }
        public DbSet<MonthlyExpenses> MonthlyExpenses { get; set; }
        public DbSet<YearlyExpenses> YearlyExpenses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Blank");
    }
    public class MonthlyExpenses
    {
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string Time { get; set; }
        public string ItemCategory { get; set; }
    }
    public class YearlyExpenses
    {
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string Time { get; set; }
        public string ItemCategory { get; set; }
    }
    
}
