using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAuthProj.Migrations
{
    public partial class ModifieJobModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "Jobs",
                newName: "OpeningDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDeadline",
                table: "Jobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationProcedure",
                table: "Jobs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsibilities",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationDeadline",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ApplicationProcedure",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Responsibilities",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "OpeningDate",
                table: "Jobs",
                newName: "ExpirationDate");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);
        }
    }
}
