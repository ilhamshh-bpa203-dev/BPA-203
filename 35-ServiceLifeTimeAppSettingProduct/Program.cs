
using _34_Front_To_BackSqlConnection.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")
    //["ConnectionStrings:Default"] bu kohne usul
    )
);


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    "Default",
    "{controller=home}/{action=index}/{id?}"
    );

app.Run();

