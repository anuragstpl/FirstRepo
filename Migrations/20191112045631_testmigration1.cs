using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsApi.Migrations
{
    public partial class testmigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ACCESS_LEVEL",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "READ_ONLY",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACCESS_LEVEL",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "READ_ONLY",
                table: "Contacts");
        }
    }
}
