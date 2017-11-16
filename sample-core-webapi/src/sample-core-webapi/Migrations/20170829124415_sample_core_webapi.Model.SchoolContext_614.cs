using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace samplecorewebapi.Migrations
{
    public partial class sample_core_webapiModelSchoolContext_614 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Students",
                nullable: true);
        }
    }
}
