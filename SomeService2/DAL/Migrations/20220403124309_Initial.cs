using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SomeService2.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    OrganizationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ООО Ромашка" },
                    { 2, "Сбербанк г. Москва" },
                    { 3, "Рога и копыта" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "MiddleName", "Name", "OrganizationId", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "bretbas@mail.ru", "Сергеевич", "Максим", 1, "+79997820793", "Шилов" },
                    { 2, null, "Геннадьевич", "Сергей", 1, null, "Петров" },
                    { 3, null, "Петрович", "Николай", 1, "+79111211122", "Жуков" },
                    { 4, "petrov@mail.ru", "Аркадьевич", "Максим", 1, "+79922321122", "Бахур" },
                    { 5, null, "Сергеевич", "Геннадий", 1, null, null },
                    { 6, null, null, "Петр", 2, null, "Демченко" },
                    { 7, null, "Семеновна", "Алиса", 1, "+79201239393", "Грибоедова" },
                    { 8, null, "Семеновна", "Галина", 2, null, null },
                    { 9, "elena@yandex.ru", "Семеновна", "Галина", 3, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_OrganizationId",
                table: "users",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
