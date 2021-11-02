using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace assignment_1_backend.Migrations
{
    public partial class improvements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_UserID",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UserID",
                table: "Devices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "062dd302-cf69-4025-bfbe-07d1cece4eff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3c5fea2-e06f-4e30-adbc-aa3165ce1a8f");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceID",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29805658-3222-4cfe-9d50-342b04d4d50a", "d85dde62-a2da-4023-9505-8d85ea086047", "Client", "CLIENT" },
                    { "71e55b33-c3bf-40c1-bb63-ff96c5df8d63", "a1acf98e-3835-4c76-9533-18d105dafa41", "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DeviceID",
                table: "AspNetUsers",
                column: "DeviceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Devices_DeviceID",
                table: "AspNetUsers",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Devices_DeviceID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DeviceID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29805658-3222-4cfe-9d50-342b04d4d50a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e55b33-c3bf-40c1-bb63-ff96c5df8d63");

            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3c5fea2-e06f-4e30-adbc-aa3165ce1a8f", "39e48032-e3f4-46c8-9f60-67ae6dac5b53", "Client", "CLIENT" },
                    { "062dd302-cf69-4025-bfbe-07d1cece4eff", "46841379-62e9-4247-b15b-5baf5bb35feb", "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserID",
                table: "Devices",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_UserID",
                table: "Devices",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
