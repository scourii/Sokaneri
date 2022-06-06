using Sokaneri.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Sokaneri.Areas.Identity;
using Microsoft.AspNetCore.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) => {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(context.Configuration.GetConnectionString("SakuriDBConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        });
    }
}