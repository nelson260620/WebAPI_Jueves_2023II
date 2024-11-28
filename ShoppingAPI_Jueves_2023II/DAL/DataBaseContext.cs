using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2023II.DAL.Entities;
using System.Diagnostics.Metrics;

namespace ShoppingAPI_Jueves_2023II.DAL
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        //este metodo es propio de entities framework core me sirve para configurar unos indices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c=>c.Name).IsUnique();//aqui creo un indice del capo name para la tabla country
        }
        #region Dbsets
        public DbSet<Country> Countries { get; set; }
        #endregion
    }
}
