using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminPanelAgain.Migrations
{
    public partial class ChangeIntoUserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDbs_Countries_CountryId",
                table: "UserDbs");

            migrationBuilder.DropIndex(
                name: "IX_UserDbs_CountryId",
                table: "UserDbs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UserDbs");

            migrationBuilder.AddColumn<int>(
                name: "CountryIds",
                table: "UserDbs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "UserDbs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDbs_CountryIds",
                table: "UserDbs",
                column: "CountryIds");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDbs_Countries_CountryIds",
                table: "UserDbs",
                column: "CountryIds",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDbs_Countries_CountryIds",
                table: "UserDbs");

            migrationBuilder.DropIndex(
                name: "IX_UserDbs_CountryIds",
                table: "UserDbs");

            migrationBuilder.DropColumn(
                name: "CountryIds",
                table: "UserDbs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "UserDbs");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UserDbs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDbs_CountryId",
                table: "UserDbs",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDbs_Countries_CountryId",
                table: "UserDbs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
