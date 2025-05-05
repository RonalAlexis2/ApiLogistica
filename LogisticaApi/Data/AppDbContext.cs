using LogisticaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticaApi.Data
{
    

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Puerto> Puertos { get; set; }
        public DbSet<EnvioTerrestre> EnviosTerrestres { get; set; }
        public DbSet<EnvioMaritimo> EnviosMaritimos { get; set; }





    }
}

