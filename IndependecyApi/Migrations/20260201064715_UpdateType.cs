using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndependecyApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Update_Date",
                table: "Types",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Update_Date",
                table: "Types");
        }
    }
}
