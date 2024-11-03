using Microsoft.EntityFrameworkCore;
using Crud.Domain.Entities;


namespace Crud.Web.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }

        //CREO QUE LO DEBO BORRAR :v
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasIndex(p => p.Id).IsUnique();

        }
    }
}
