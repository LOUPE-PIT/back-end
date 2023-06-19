using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogService.DataAccessLayer.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EndSynchronizationId",
                table: "Logs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StartSynchronizationId",
                table: "Logs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndSynchronizationId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "StartSynchronizationId",
                table: "Logs");
        }
    }
}
