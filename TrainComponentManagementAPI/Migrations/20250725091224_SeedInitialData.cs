using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainComponentManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "CanAssignQuantity", "Name", "Quantity", "UniqueNumber" },
                values: new object[,]
                {
                    { 1, false, "Engine", null, "ENG123" },
                    { 2, false, "Passenger Car", null, "PAS456" },
                    { 3, false, "Freight Car", null, "FRT789" },
                    { 4, true, "Wheel", null, "WHL101" },
                    { 5, true, "Seat", null, "STS234" },
                    { 6, true, "Window", null, "WIN567" },
                    { 7, true, "Door", null, "DR123" },
                    { 8, true, "Control Panel", null, "CTL987" },
                    { 9, true, "Light", null, "LGT456" },
                    { 10, true, "Brake", null, "BRK789" },
                    { 11, true, "Bolt", null, "BLT321" },
                    { 12, true, "Nut", null, "NUT654" },
                    { 13, false, "Engine Hood", null, "EH789" },
                    { 14, false, "Axle", null, "AX456" },
                    { 15, false, "Piston", null, "PST789" },
                    { 16, true, "Handrail", null, "HND234" },
                    { 17, true, "Step", null, "STP567" },
                    { 18, false, "Roof", null, "RF123" },
                    { 19, false, "Air Conditioner", null, "AC789" },
                    { 20, false, "Flooring", null, "FLR456" },
                    { 21, true, "Mirror", null, "MRR789" },
                    { 22, false, "Horn", null, "HRN321" },
                    { 23, false, "Coupler", null, "CPL654" },
                    { 24, true, "Hinge", null, "HNG987" },
                    { 25, true, "Ladder", null, "LDR456" },
                    { 26, false, "Paint", null, "PNT789" },
                    { 27, true, "Decal", null, "DCL321" },
                    { 28, true, "Gauge", null, "GGS654" },
                    { 29, false, "Battery", null, "BTR987" },
                    { 30, false, "Radiator", null, "RDR456" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
