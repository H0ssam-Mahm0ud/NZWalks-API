using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("678c41a8-3df5-4b23-8f3e-194ff06b2056"), "Hard" },
                    { new Guid("a93ff308-a1a5-43b5-8aa1-bffff3ddd44b"), "Medium" },
                    { new Guid("fc472633-3da0-4844-945d-ae2b1fb7d6d8"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("06874890-fb2c-48ba-aae3-3a5d228ff446"), "Sul", "Sutherland", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRJeZ2Kjks3UVg6A6_hfkx2N7ApDtF7esuIWkTfe3_jPMsOO8NJm2tWEL4nGbr870GpTY&usqp=CAU" },
                    { new Guid("11f3fc30-888f-4de6-a13c-dfe84c19a281"), "Par", "Paris", "https://images.unsplash.com/photo-1502602898657-3e91760cbb34?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8cGFyaXN8ZW58MHx8MHx8fDA%3D" },
                    { new Guid("53012cc3-2f72-445e-9133-f5cce605ebdd"), "Rus", "Russia", "https://penntoday.upenn.edu/sites/default/files/2022-02/Russian-Disinformation-PWH.jpg" },
                    { new Guid("c0652939-bf95-4cf1-a40f-3d6e998638b9"), "Gem", "Germany", "https://etimg.etb2bimg.com/photo/93896068.cms" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("678c41a8-3df5-4b23-8f3e-194ff06b2056"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a93ff308-a1a5-43b5-8aa1-bffff3ddd44b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fc472633-3da0-4844-945d-ae2b1fb7d6d8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("06874890-fb2c-48ba-aae3-3a5d228ff446"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("11f3fc30-888f-4de6-a13c-dfe84c19a281"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("53012cc3-2f72-445e-9133-f5cce605ebdd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c0652939-bf95-4cf1-a40f-3d6e998638b9"));
        }
    }
}
