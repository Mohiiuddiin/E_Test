using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Test.Data.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NCD_Id",
                table: "NCD_Details");

            migrationBuilder.DropColumn(
                name: "Patient_Id",
                table: "NCD_Details");

            migrationBuilder.DropColumn(
                name: "Allergies_Id",
                table: "Allergies_Details");

            migrationBuilder.DropColumn(
                name: "Patient_Id",
                table: "Allergies_Details");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NCD_Id",
                table: "NCD_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Patient_Id",
                table: "NCD_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Allergies_Id",
                table: "Allergies_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Patient_Id",
                table: "Allergies_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
