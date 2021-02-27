using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelListing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.DbContexts.Configuration
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.Property(a => a.ShortName).HasMaxLength(50);
            builder.HasData(
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
        }
    }
}
