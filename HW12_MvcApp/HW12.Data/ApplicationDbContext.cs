
using Microsoft.EntityFrameworkCore;
using HW12.Models;
using HW12.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace HW12.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            new DbInitializer(modelBuilder).Seed();
        }

    }
}
