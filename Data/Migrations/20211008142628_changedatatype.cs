using Microsoft.EntityFrameworkCore.Migrations;

namespace TechTreeMVCWebApplication.Data.Migrations
{
    public partial class changedatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "AspNetUsers",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "SecondName");
        }
    }
}
