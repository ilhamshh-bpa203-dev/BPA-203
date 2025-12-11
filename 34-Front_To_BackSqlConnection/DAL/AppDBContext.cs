using _34_Front_To_BackSqlConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace _34_Front_To_BackSqlConnection.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
    }
}
