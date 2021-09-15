using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationApp.DataStore.Migrations
{
    public partial class DonationForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCategory",
                table: "Donors");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Donors",
                newName: "Signature");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceCondition",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceSpecification",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemOwnership",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForDonation",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DeviceCondition",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DeviceSpecification",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "ItemOwnership",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "ReasonForDonation",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "Donees");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Donees");

            migrationBuilder.RenameColumn(
                name: "Signature",
                table: "Donors",
                newName: "Model");

            migrationBuilder.AddColumn<int>(
                name: "ItemCategory",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
