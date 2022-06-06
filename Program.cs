using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Sokaneri.Areas.Identity;
using Microsoft.AspNetCore.HttpOverrides;
using Sokaneri;
using Microsoft.Extensions.Configuration;
using System.Net;
using Newtonsoft.Json.Serialization;
using Blazored.Modal;
using Blazored.LocalStorage;
using Blazored.Toast;
using Sokaneri.Services;
using System.Security.Claims;
using Sokaneri.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
builder.WebHost.UseWebRoot("wwwroot").UseStaticWebAssets();
builder.Services.AddRazorPages();
builder.WebHost.UseStaticWebAssets();
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SakuriDBConnection"));
}); 

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
.AddNewtonsoftJson(options=> options.SerializerSettings.ContractResolver = new DefaultContractResolver());
builder.Services.AddControllers();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthentication("Identity.Application").AddCookie();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();
//builder.Services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.Name);
//builder.Services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserNameClaimType = ClaimTypes.Name);
builder.Services.AddTransient<AccountService>();
builder.Services.AddSingleton<ViewOptionService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {

    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedAccount = false;

}).AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI();
/* builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false )
    .AddEntityFrameworkStores<ApplicationDbContext>();
*/ 

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

var app = builder.Build(); 

builder.WebHost.ConfigureKestrel(options =>
{
    byte[] localhost = { 127, 0, 0, 1 };
    IPAddress address = new IPAddress(localhost);
    options.Listen(address, Int32.Parse(Configuration["Sokaneri:Https"]), listenOptions =>
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
            listenOptions.UseHttps(Configuration["SSL_Cert:Path"],
                                    Configuration["SSL_Cert:Password"]);
        else
            listenOptions.UseHttps();
    });
});

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
// Configure the HTTP request pipeline.
/*(if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
*/
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
