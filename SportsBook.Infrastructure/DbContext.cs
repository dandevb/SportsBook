using Microsoft.EntityFrameworkCore;
using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Configurations;

namespace SportsBook.Infrastructure
{
    public class SportsBookDB: DbContext
    {
        protected string defaultConnectionString = @"Server=localhost;Database=SportsBookDB;Trusted_Connection=True;Integrated Security=true;";
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<SportEvent> SportEvents { get; set; }

        public SportsBookDB(DbContextOptions<SportsBookDB> options) : base(options)
        {   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(defaultConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SportEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SelectionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MarketEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SportEventEntityConfiguration());
        }
    }
}
