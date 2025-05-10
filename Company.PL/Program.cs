using Microsoft.EntityFrameworkCore;
using Company.DAL.Contexts;
using Company.PL.Data;
using Microsoft.AspNetCore.Identity;
using Company.PL.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'CompanyPLDbContextConnection' not found.");

builder.Services.AddDbContext<CompanyPLDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AuthUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CompanyPLDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddRazorPages();
// Register DbContext
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
