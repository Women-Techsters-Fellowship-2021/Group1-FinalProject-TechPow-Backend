using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationApp.DataStore.Migrations
{
    public partial class DoneeAppUpdateMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdateRequest",
                table: "DonorForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "DoneeApplication",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateRequest",
                table: "DonorForm");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "DoneeApplication");
        }
    }
}
