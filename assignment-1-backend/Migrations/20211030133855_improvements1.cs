using Microsoft.EntityFrameworkCore.Migrations;

namespace assignment_1_backend.Migrations
{
    public partial class improvements1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29805658-3222-4cfe-9d50-342b04d4d50a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e55b33-c3bf-40c1-bb63-ff96c5df8d63");

            migrationBuilder.AddColumn<double>(
                name: "MAximumValue",
                table: "Devices",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf07e3c9-ea74-428a-b12f-81b067826efc", "13f58ae9-d9ac-4177-b9f3-627c38ac2550", "Client", "CLIENT" },
                    { "bd8cc354-1501-4e6d-a38f-65f1a7861b32", "9a07c2cd-a527-49cf-a078-1a9903f4589b", "Manager", "MANAGER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd8cc354-1501-4e6d-a38f-65f1a7861b32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf07e3c9-ea74-428a-b12f-81b067826efc");

            migrationBuilder.DropColumn(
                name: "MAximumValue",
                table: "Devices");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29805658-3222-4cfe-9d50-342b04d4d50a", "d85dde62-a2da-4023-9505-8d85ea086047", "Client", "CLIENT" },
                    { "71e55b33-c3bf-40c1-bb63-ff96c5df8d63", "a1acf98e-3835-4c76-9533-18d105dafa41", "Manager", "MANAGER" }
                });
        }
    }
}
