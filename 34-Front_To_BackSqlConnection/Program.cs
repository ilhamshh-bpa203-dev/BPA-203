<<<<<<< HEAD
using _34_Front_To_BackSqlConnection.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseSqlServer(
        "server=PC;database=ProniaBPA203DB; trusted_connection=true; trustServerCertificate=true"
    )
);

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    "Default",
    "{controller=home}/{action=index}/{id?}"
    );

app.Run();
=======
using _34_Front_To_BackSqlConnection.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseSqlServer(
        "server=PC;database=ProniaBPA203DB; trusted_connection=true; trustServerCertificate=true"
    )
);

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    "Default",
    "{controller=home}/{action=index}/{id?}"
    );

app.Run();
>>>>>>> 00a059a49c84f9e4f56c3f29b814fd91c6c3076f
