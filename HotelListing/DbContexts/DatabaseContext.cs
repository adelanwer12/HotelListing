using Microsoft.EntityFrameworkCore;
using HotelListing.DbContexts.Configuration;
using HotelListing.Models;

namespace HotelListing.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Hostel> Hostels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfigurations());
            modelBuilder.ApplyConfiguration(new HotelConfigurations());
            modelBuilder.ApplyConfiguration(new HostelConfigurations());
        }
    }
}
