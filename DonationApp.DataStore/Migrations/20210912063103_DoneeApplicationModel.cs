using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationApp.DataStore.Migrations
{
    public partial class DoneeApplicationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortBio",
                table: "Donees",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "MaritalStatus",
                table: "Donees",
                newName: "EduLevel");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Donees",
                newName: "Signature");

            migrationBuilder.RenameColumn(
                name: "CareerStatus",
                table: "Donees",
                newName: "Country");

            migrationBuilder.AlterColumn<int>(
                name: "ItemNeeded",
                table: "Donees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DOB",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LetterOfRecLink",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalIdLink",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgContact",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgName",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgWebsite",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForApplication",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "Donees");

            migrationBuilder.DropColumn(
                name: "LetterOfRecLink",
                table: "Donees");

            migrationBuilder.DropColumn(
                name: "NationalIdLink",
                table: "Donees");

            migrationBuilder.DropColumn(
                name: "OrgContact",
                table: "Donees");

            migrationBuilder.DropColumn(
                name: "OrgName",
                table: "Donees");

            migrationBuilder.DropColumn(
                name: "OrgWebsite",
                table: "Donees");

            migrationBuilder.DropColumn(
                name: "ReasonForApplication",
                table: "Donees");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Donees",
                newName: "ShortBio");

            migrationBuilder.RenameColumn(
                name: "Signature",
                table: "Donees",
                newName: "ItemID");

            migrationBuilder.RenameColumn(
                name: "EduLevel",
                table: "Donees",
                newName: "MaritalStatus");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Donees",
                newName: "CareerStatus");

            migrationBuilder.AlterColumn<string>(
                name: "ItemNeeded",
                table: "Donees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Donees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
