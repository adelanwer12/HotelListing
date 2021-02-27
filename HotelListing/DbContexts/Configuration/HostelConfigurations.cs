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
    public class HostelConfigurations: IEntityTypeConfiguration<Hostel>
    {
        public void Configure(EntityTypeBuilder<Hostel> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Address).IsRequired().HasMaxLength(150);
            builder.HasData(
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
                    Name = "Hostel 2 Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("d05aaafb-1ac1-4c94-8582-b97dbbe2836b")
                },
                new Hostel
                {
                    Id = Guid.Parse("0b76fe3d-486d-4508-95d9-73ce5840bd5b"),
                    Name = "Hostel 3 Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("b9923232-d27e-4af4-8768-6c58ad665d45")
                },
                new Hostel
                {
                    Id = Guid.Parse("723a9bfd-bfe9-4b44-bae3-340d5441aabe"),
                    Name = "Hostel 4 Resort and Spa",
                    Address = "Cairo",
                    Rating = 4.5,
                    CountryId = Guid.Parse("71cad3bd-df3c-47d0-b621-3de868fcaa69")
                });
        }
    }
}
