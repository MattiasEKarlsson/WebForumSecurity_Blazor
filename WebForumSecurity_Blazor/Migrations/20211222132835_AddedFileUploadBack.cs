using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForumSecurity_Blazor.Migrations
{
    public partial class AddedFileUploadBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "File");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "File");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "File",
                newName: "UntrustedName");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "File",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "File",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "File",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "File");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "File");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "File");

            migrationBuilder.RenameColumn(
                name: "UntrustedName",
                table: "File",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "File",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "File",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
