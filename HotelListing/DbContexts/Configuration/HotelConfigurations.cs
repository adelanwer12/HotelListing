using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelListing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.DbContexts.Configuration
{
    public class HotelConfigurations: IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Address).IsRequired().HasMaxLength(150);
            builder.HasData(
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
        }
    }
}
