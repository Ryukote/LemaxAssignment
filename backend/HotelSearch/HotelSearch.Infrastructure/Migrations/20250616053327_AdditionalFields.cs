using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSearch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Hotel",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Hotel",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Hotel",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Hotel");
        }
    }
}
