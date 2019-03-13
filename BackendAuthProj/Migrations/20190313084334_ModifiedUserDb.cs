using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAuthProj.Migrations
{
    public partial class ModifiedUserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infos_AspNetUsers_UserDbId",
                table: "Infos");

            migrationBuilder.DropForeignKey(
                name: "FK_Internships_AspNetUsers_UserDbId",
                table: "Internships");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_UserDbId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_UserDbId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Internships_UserDbId",
                table: "Internships");

            migrationBuilder.DropIndex(
                name: "IX_Infos_UserDbId",
                table: "Infos");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "Internships");

            migrationBuilder.DropColumn(
                name: "UserDbId",
                table: "Infos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserDbId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDbId",
                table: "Internships",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDbId",
                table: "Infos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserDbId",
                table: "Jobs",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_UserDbId",
                table: "Internships",
                column: "UserDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_UserDbId",
                table: "Infos",
                column: "UserDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Infos_AspNetUsers_UserDbId",
                table: "Infos",
                column: "UserDbId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_AspNetUsers_UserDbId",
                table: "Internships",
                column: "UserDbId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_UserDbId",
                table: "Jobs",
                column: "UserDbId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
