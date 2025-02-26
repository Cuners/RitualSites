using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Register services here
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "info",
    pattern: "{controller=Info}/{action=Index}/{id?}"
   );
app.MapControllerRoute(
    name: "products",
    pattern: "{controller=Products}/{action=Index}/{id?}"
   );
app.MapControllerRoute(
    name: "services",
    pattern: "{controller=Services}/{action=Index}/{id?}"
   );
app.Run();
public partial class Program1 { }
