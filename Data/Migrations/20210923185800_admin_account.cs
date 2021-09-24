using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace TechTreeMVCWebApplication.Data.Migrations
{
    public partial class admin_account : Migration
    {
        const string Admin_User_GUID = "94e1d10e-e3b7-4348-9e2c-65fe316bbaaf";
        const string Admin_Role_GUID = "4ab41a22-c732-43b9-9f0e-678e3fec2c67";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, "Passw0rd1993");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[AspNetUsers]([Id],[UserName],[EmailConfirmed],[AccessFailedCount],[TwoFactorEnabled],[LockoutEnabled],[PhoneNumberConfirmed],[Email],[PasswordHash],[FirstName],[SecondName])");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{Admin_User_GUID}'");

            sb.AppendLine(",'admin@techtree.com'");
            sb.AppendLine(",'1'");
            sb.AppendLine(",'1'");
            sb.AppendLine(",'1'");
            sb.AppendLine(",'1'");
            sb.AppendLine(",'1'");
            sb.AppendLine(",'admin@techtree.com'");
            sb.AppendLine($",'{passwordHash}'");

         
            sb.AppendLine(",'Admin'");
            sb.AppendLine(",'TechTree'");

            sb.AppendLine(")");
            migrationBuilder.Sql(sb.ToString());
            migrationBuilder.Sql($"INSERT INTO [dbo].[AspNetRoles]([Id],[Name],[NormalizedName])Values('{Admin_Role_GUID}','Admin','Admin')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[AspNetUSerRoles](UserId,RoleId)Values('{Admin_User_GUID}','{Admin_Role_GUID}')");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
