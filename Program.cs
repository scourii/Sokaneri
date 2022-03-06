using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Sakuri.Areas.Identity;
using Sakuri.Data;
using Sakuri;
using Newtonsoft.Json.Serialization;
using Blazored.Modal;
using Blazored.Toast;
using Sakuri.Services;
using Sakuri.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddDbContext<SakuriContext>(options =>
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
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthentication("Identity.Application").AddCookie();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<AccountService>();
builder.Services.AddSingleton<MoneyInformationService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {

    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedAccount = false;

}).AddDefaultTokenProviders().AddEntityFrameworkStores<SakuriContext>().AddDefaultUI();
/* builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false )
    .AddEntityFrameworkStores<ApplicationDbContext>();
*/ 
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
