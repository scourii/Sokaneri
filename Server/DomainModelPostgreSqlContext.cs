using Sakuri.Models;
using Microsoft.EntityFrameworkCore;

namespace Sakuri.Server
{
    public class DomainModelPostgreSqlContext
    {
        public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
        {

        }
        public DbSet<User> user { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            ChangeReturn.DetectChanges();
            return base.SaveChanges();
        }
    }
}
