using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManager.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Venues",
                newName: "CurrentStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Atendees",
                newName: "CurrentStatus");

            migrationBuilder.AlterColumn<int>(
                name: "HouseNumber",
                table: "Venues",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Atendees",
                columns: new[] { "Id", "CurrentStatus", "Description", "Name", "ProfilePicPath" },
                values: new object[,]
                {
                    { 1, 0, "Comediante e ator do porta dos fundos", "Rafael Portugal", "" },
                    { 2, 0, "Palhaço profissional", "Palhaço Tubinho", "" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "ericmoura@gmail.com", "Eric Moura", "coxinha123" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "City", "Country", "CurrentStatus", "HouseNumber", "Name", "Neighborhood", "State" },
                values: new object[] { 1, "Guaratinguetá", "Brasil", 0, 82, "Estação", "Praça Condessa de Frontin", "São paulo" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "OrganizerId", "Title", "VenueId" },
                values: new object[] { 1, new DateTime(2025, 3, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), "Uma palestra apresentada por um comediante do porta dos fundos, explorando a ideia por trás das risadas.", 1, "Palestra sobre comédia", 1 });

            migrationBuilder.InsertData(
                table: "EventHasAtendee",
                columns: new[] { "AtendeesId", "EventsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventHasAtendee",
                keyColumns: new[] { "AtendeesId", "EventsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EventHasAtendee",
                keyColumns: new[] { "AtendeesId", "EventsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Atendees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Atendees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "CurrentStatus",
                table: "Venues",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CurrentStatus",
                table: "Atendees",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "Venues",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
