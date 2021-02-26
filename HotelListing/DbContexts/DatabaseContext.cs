using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = Guid.Parse("6069422e-0248-44fd-b969-9626b14df3c2"),
                    Name = "Egypt",
                    ShortName = "Egy"
                },
                new Country
                {
                    Id = Guid.Parse("d05aaafb-1ac1-4c94-8582-b97dbbe2836b"),
                    Name = "Sudan",
                    ShortName = "Sn"
                },
                new Country
                {
                    Id = Guid.Parse("b9923232-d27e-4af4-8768-6c58ad665d45"),
                    Name = "Libya",
                    ShortName = "Li"
                },
                new Country
                {
                    Id = Guid.Parse("71cad3bd-df3c-47d0-b621-3de868fcaa69"),
                    Name = "Jamaica",
                    ShortName = "Jm"
                });
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = Guid.Parse("4353d1b0-4661-4217-a31b-fc4296896caa"),
                    Name = "Sandals Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("6069422e-0248-44fd-b969-9626b14df3c2")
                },
                new Hotel
                {
                    Id = Guid.Parse("e42ab626-1e82-4c23-98e5-d39f078fadf9"),
                    Name = "Sta Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("d05aaafb-1ac1-4c94-8582-b97dbbe2836b")
                },
                new Hotel
                {
                    Id = Guid.Parse("68daa73b-7914-4742-92b3-a79873da4ecc"),
                    Name = "Mgme Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("b9923232-d27e-4af4-8768-6c58ad665d45")
                },
                new Hotel
                {
                    Id = Guid.Parse("b57b14e7-0622-41b3-8c91-80bd943736db"),
                    Name = "New Rose Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("71cad3bd-df3c-47d0-b621-3de868fcaa69")
                });
            modelBuilder.Entity<Hostel>().HasData(
                new Hostel
                {
                    Id = Guid.Parse("458a2291-e139-428b-bc96-f26e9d176cd5"),
                    Name = "Hostel 1 Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("6069422e-0248-44fd-b969-9626b14df3c2")
                },
                new Hostel
                {
                    Id = Guid.Parse("25981683-c283-465c-81f5-5243f156f788"),
                    Name = "Hostel 1 Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("d05aaafb-1ac1-4c94-8582-b97dbbe2836b")
                },
                new Hostel
                {
                    Id = Guid.Parse("0b76fe3d-486d-4508-95d9-73ce5840bd5b"),
                    Name = "Hostel 1 Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("b9923232-d27e-4af4-8768-6c58ad665d45")
                },
                new Hostel
                {
                    Id = Guid.Parse("723a9bfd-bfe9-4b44-bae3-340d5441aabe"),
                    Name = "Hostel 1 Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("71cad3bd-df3c-47d0-b621-3de868fcaa69")
                });
        }
    }
}
