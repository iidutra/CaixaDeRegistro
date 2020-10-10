using CaixaDeRegistro.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MaquinaDeTroco.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Moeda> Moedas { get; set; }
        public DbSet<Sangria> Sangrias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(250)");
            }
        }
    }
}
