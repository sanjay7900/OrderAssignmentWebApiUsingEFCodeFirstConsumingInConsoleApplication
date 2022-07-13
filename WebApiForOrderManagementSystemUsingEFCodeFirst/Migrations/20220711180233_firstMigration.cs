using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiForOrderManagementSystemUsingEFCodeFirst.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(40)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: false),
                    PhoneNumber = table.Column<decimal>(type: "numeric", nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMaster_EmailAddress",
                table: "CustomerMaster",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_Name",
                table: "ItemMaster",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMaster");

            migrationBuilder.DropTable(
                name: "ItemMaster");
        }
    }
}
