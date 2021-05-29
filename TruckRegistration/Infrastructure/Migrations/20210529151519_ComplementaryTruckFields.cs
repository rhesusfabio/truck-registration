using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TruckRegistration.Infrastructure.Migrations
{
    public partial class ComplementaryTruckFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufactureModel",
                table: "Trucks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufactureYear",
                table: "Trucks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModelString",
                table: "Trucks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufactureModel",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "ManufactureYear",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "ModelString",
                table: "Trucks");
        }
    }
}
