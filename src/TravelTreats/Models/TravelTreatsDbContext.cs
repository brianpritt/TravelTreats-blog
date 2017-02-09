using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace TravelTreats.Models
{
    public class TravelTreatsDbContext : DbContext
    {
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Encounter> Encounters { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelTreatsWithMigrations;integrated security=True");
        }

        public TravelTreatsDbContext(DbContextOptions<TravelTreatsDbContext> options) : base(options)
        {
        }

        public TravelTreatsDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    
    }
}