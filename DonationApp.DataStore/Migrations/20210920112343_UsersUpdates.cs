using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationApp.DataStore.Migrations
{
    public partial class UsersUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorForm_AspNetUsers_userId",
                table: "DonorForm");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "DonorForm",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "DonorForm",
                newName: "LastName");

            migrationBuilder.RenameIndex(
                name: "IX_DonorForm_userId",
                table: "DonorForm",
                newName: "IX_DonorForm_UserId");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "DoneeApplication",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "DonorForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "DoneeApplication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoneeAppsId",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonorFormsId",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DoneeAppsId",
                table: "Donations",
                column: "DoneeAppsId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorFormsId",
                table: "Donations",
                column: "DonorFormsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_DoneeApplication_DoneeAppsId",
                table: "Donations",
                column: "DoneeAppsId",
                principalTable: "DoneeApplication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_DonorForm_DonorFormsId",
                table: "Donations",
                column: "DonorFormsId",
                principalTable: "DonorForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorForm_AspNetUsers_UserId",
                table: "DonorForm",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_DoneeApplication_DoneeAppsId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_DonorForm_DonorFormsId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorForm_AspNetUsers_UserId",
                table: "DonorForm");

            migrationBuilder.DropIndex(
                name: "IX_Donations_DoneeAppsId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_DonorFormsId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "DonorForm");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "DoneeApplication");

            migrationBuilder.DropColumn(
                name: "DoneeAppsId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "DonorFormsId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DonorForm",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "DonorForm",
                newName: "FullName");

            migrationBuilder.RenameIndex(
                name: "IX_DonorForm_UserId",
                table: "DonorForm",
                newName: "IX_DonorForm_userId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "DoneeApplication",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorForm_AspNetUsers_userId",
                table: "DonorForm",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
