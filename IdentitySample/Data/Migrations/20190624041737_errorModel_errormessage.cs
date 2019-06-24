using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentitySample.Data.Migrations
{
    public partial class errorModel_errormessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "ErrorViewModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "ErrorViewModel");
        }
    }
}
