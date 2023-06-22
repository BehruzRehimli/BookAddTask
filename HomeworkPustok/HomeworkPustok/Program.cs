using HomeworkPustok.DAL;
using HomeworkPustok.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<LayoutService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PustokDbContext>(opt=>opt.UseSqlServer("Server=LAPTOP-RJLDMUKC\\SQLEXPRESS;Database=Pustok;Trusted_Connection=True"));

var app = builder.Build();


app.UseStaticFiles();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
