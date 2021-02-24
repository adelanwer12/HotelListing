using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { new Guid("6069422e-0248-44fd-b969-9626b14df3c2"), "Egypt", "Egy" },
                    { new Guid("d05aaafb-1ac1-4c94-8582-b97dbbe2836b"), "Sudan", "Sn" },
                    { new Guid("b9923232-d27e-4af4-8768-6c58ad665d45"), "Libya", "Li" },
                    { new Guid("71cad3bd-df3c-47d0-b621-3de868fcaa69"), "Jamaica", "Jm" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("4353d1b0-4661-4217-a31b-fc4296896caa"), "Cairo", new Guid("6069422e-0248-44fd-b969-9626b14df3c2"), "Sandals Resort and Spa", 4.5 },
                    { new Guid("e42ab626-1e82-4c23-98e5-d39f078fadf9"), "Cairo", new Guid("d05aaafb-1ac1-4c94-8582-b97dbbe2836b"), "Sandals Resort and Spa", 4.5 },
                    { new Guid("68daa73b-7914-4742-92b3-a79873da4ecc"), "Cairo", new Guid("b9923232-d27e-4af4-8768-6c58ad665d45"), "Sandals Resort and Spa", 4.5 },
                    { new Guid("b57b14e7-0622-41b3-8c91-80bd943736db"), "Cairo", new Guid("71cad3bd-df3c-47d0-b621-3de868fcaa69"), "Sandals Resort and Spa", 4.5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("4353d1b0-4661-4217-a31b-fc4296896caa"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("68daa73b-7914-4742-92b3-a79873da4ecc"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b57b14e7-0622-41b3-8c91-80bd943736db"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e42ab626-1e82-4c23-98e5-d39f078fadf9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6069422e-0248-44fd-b969-9626b14df3c2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("71cad3bd-df3c-47d0-b621-3de868fcaa69"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b9923232-d27e-4af4-8768-6c58ad665d45"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d05aaafb-1ac1-4c94-8582-b97dbbe2836b"));
        }
    }
}
