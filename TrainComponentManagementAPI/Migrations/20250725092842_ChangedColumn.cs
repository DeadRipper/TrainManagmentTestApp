using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainComponentManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CanAssignQuantity",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 2,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 3,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 4,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 5,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 6,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 7,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 8,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 9,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 10,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 11,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 12,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 13,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 14,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 15,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 16,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 17,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 18,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 19,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 20,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 21,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 22,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 23,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 24,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 25,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 26,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 27,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 28,
                column: "CanAssignQuantity",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 29,
                column: "CanAssignQuantity",
                value: "No");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 30,
                column: "CanAssignQuantity",
                value: "No");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CanAssignQuantity",
                table: "Components",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 2,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 3,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 4,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 5,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 6,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 7,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 8,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 9,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 10,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 11,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 12,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 13,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 14,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 15,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 16,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 17,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 18,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 19,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 20,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 21,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 22,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 23,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 24,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 25,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 26,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 27,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 28,
                column: "CanAssignQuantity",
                value: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 29,
                column: "CanAssignQuantity",
                value: false);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 30,
                column: "CanAssignQuantity",
                value: false);
        }
    }
}
