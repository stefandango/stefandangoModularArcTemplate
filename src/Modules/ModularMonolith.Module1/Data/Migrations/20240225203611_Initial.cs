using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModularMonolith.Module1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Module1Objects");

            migrationBuilder.CreateTable(
                name: "Module1Objects",
                schema: "Module1Objects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module1Objects", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Module1Objects",
                table: "Module1Objects",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("04069dc5-c48e-4171-8828-32dd98b074b0"), "Object_3", 47 },
                    { new Guid("61b40c33-4640-407e-8b7e-ebb69217f04c"), "Object_1", 35 },
                    { new Guid("d595a08e-4675-434a-9c74-e6d9a76d6d91"), "Object_2", 32 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module1Objects",
                schema: "Module1Objects");
        }
    }
}
