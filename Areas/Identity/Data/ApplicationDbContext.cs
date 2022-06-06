using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sokaneri.Models;

namespace Sokaneri.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } 
        public DbSet<ApplicationUser> ApplicationUser { get; set;}
        
        public DbSet<Items> Items { get; set; }
        
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseNpgsql("SakuriDBConnection");
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>()
            .HasKey(c=> c.UserName);
            builder.Entity<Items>()
            .HasOne(p => p.ApplicationUser)
            .WithMany(b => b.Items)
            .HasForeignKey(p => p.UserName);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}