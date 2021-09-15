using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationApp.DataStore.Migrations
{
    public partial class RenamingModelsMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donees_AspNetUsers_usersId",
                table: "Donees");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_AspNetUsers_userId",
                table: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donees",
                table: "Donees");

            migrationBuilder.RenameTable(
                name: "Donors",
                newName: "DonorForm");

            migrationBuilder.RenameTable(
                name: "Donees",
                newName: "DoneeApplication");

            migrationBuilder.RenameIndex(
                name: "IX_Donors_userId",
                table: "DonorForm",
                newName: "IX_DonorForm_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Donees_usersId",
                table: "DoneeApplication",
                newName: "IX_DoneeApplication_usersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonorForm",
                table: "DonorForm",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoneeApplication",
                table: "DoneeApplication",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoneeApplication_AspNetUsers_usersId",
                table: "DoneeApplication",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorForm_AspNetUsers_userId",
                table: "DonorForm",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoneeApplication_AspNetUsers_usersId",
                table: "DoneeApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorForm_AspNetUsers_userId",
                table: "DonorForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonorForm",
                table: "DonorForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoneeApplication",
                table: "DoneeApplication");

            migrationBuilder.RenameTable(
                name: "DonorForm",
                newName: "Donors");

            migrationBuilder.RenameTable(
                name: "DoneeApplication",
                newName: "Donees");

            migrationBuilder.RenameIndex(
                name: "IX_DonorForm_userId",
                table: "Donors",
                newName: "IX_Donors_userId");

            migrationBuilder.RenameIndex(
                name: "IX_DoneeApplication_usersId",
                table: "Donees",
                newName: "IX_Donees_usersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donees",
                table: "Donees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donees_AspNetUsers_usersId",
                table: "Donees",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_AspNetUsers_userId",
                table: "Donors",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
