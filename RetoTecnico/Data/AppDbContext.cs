using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RetoTecnico.Domain;

namespace RetoTecnico.Data
{
    public class AppDbContext : DbContext
    {
        
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Users> Users { get; set; }

        // Usuario adminitrador hardcodeado
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = modelBuilder.Entity<Users>().HasData([
                new Users
                {
                    Id = 1,
                    Username = "administrator",
                    Password = "123456",
                    Role = "ADMIN"
                }]);
        }
    }
}
