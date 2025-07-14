using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "UniqueGuId",
                table: "User",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("1c2936ec-c422-403d-92ae-338733e9c55a"));

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("98b6eca4-412c-403e-b64e-e3a0acbe5880"));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("cfbed529-1383-46bc-a32a-c39d81fbf584"));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("971cebb7-b530-468d-b4bf-332c863a877e"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("dd6807b3-89a1-4cdb-9b92-be1a7eb5905a"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("e625a692-5251-488c-8fa0-844ace163ffa"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "UniqueGuId",
                value: new Guid("9526160c-1aca-4948-b495-894203ed928f"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4,
                column: "UniqueGuId",
                value: new Guid("e6957ab7-62dc-48c1-aefc-3dc5b49049ce"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5,
                column: "UniqueGuId",
                value: new Guid("d84675ad-9c7e-4d5b-a75e-12e36925bcfd"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6,
                column: "UniqueGuId",
                value: new Guid("d8a4abcc-888d-4de0-a24f-984bdf15fa28"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7,
                column: "UniqueGuId",
                value: new Guid("da6a6499-0ba1-48c5-87bf-598626a48ec3"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 8,
                column: "UniqueGuId",
                value: new Guid("6d151bc7-4bfb-4ce6-a0ca-67422d4f8906"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 9,
                column: "UniqueGuId",
                value: new Guid("965990d2-c8d0-441f-a402-8acbd1aa713c"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 10,
                column: "UniqueGuId",
                value: new Guid("c268367e-d244-4358-8bc9-feeef0c0559c"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 11,
                column: "UniqueGuId",
                value: new Guid("a1e8d371-009d-444a-a9c5-5c0ff59d0393"));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("6542999a-83dd-4f8a-a71d-7d136d39d10b"));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("16d4d9fd-9528-4cc4-98a2-2f64c21fbdd1"));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("f5967d3a-4a7e-4d6d-aba0-2a2e894b4061"));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("802fb93c-cc76-42ce-86d9-7bacd9ddad59"));

            migrationBuilder.UpdateData(
                table: "Uom",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("ab454df2-cb1b-4964-a0e8-9180d163daa7"));

            migrationBuilder.UpdateData(
                table: "Uom",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("b2c7fae8-70f4-4ff1-9d22-330dbedb489a"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "IsDeleted", "ModifiedBy", "ModifiedDate", "PasswordHash", "Role", "UniqueGuId", "Username" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "admin@example.com", false, 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$12$HLfQhL/tjH2zrY35XCVsmex2Qup7Tr3p5Xu3CyrAVDmRA35RaxOz.", "Admin", new Guid("3447d3d5-ecdc-4223-811a-beb63443da5d"), "admin" },
                    { 2, 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "user@example.com", false, 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$12$6ngObu3BSe8Zk5/UIM1ckeNQ5wSpc7GzM1hc.1BEOBtKYkX.5.0NC", "User", new Guid("dbd751ba-42c8-416e-91fb-6fe7b7cbffa0"), "user" }
                });

            migrationBuilder.UpdateData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("c506cd5c-0726-4a20-8dfa-262a27fd41c3"));

            migrationBuilder.UpdateData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("0574d9a1-71a1-405b-852e-f859cea839c8"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "UniqueGuId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("a7054e21-4e73-4506-b14c-762152f6fe77"));

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("b256f81d-0b37-414c-8b35-f69cbf7ec836"));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("79431559-119b-41f3-9ea2-a541f7f3dd23"));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("f44a3b93-8dc7-464a-bad2-389a6823e6e2"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("9e03d235-1c38-49f6-80d5-786d89bb84bd"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("c600a402-be30-432a-aabe-48fc1427b624"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "UniqueGuId",
                value: new Guid("6395eed1-f750-44ff-8058-042674da2b8b"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4,
                column: "UniqueGuId",
                value: new Guid("a4dd18d8-bb24-414d-ad7c-48d30741eda2"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5,
                column: "UniqueGuId",
                value: new Guid("1cd5d52f-65dc-4727-88fc-241ce110bd9a"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6,
                column: "UniqueGuId",
                value: new Guid("66324452-2894-43b1-b640-11ef5b43c581"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7,
                column: "UniqueGuId",
                value: new Guid("66b3c485-84d0-4778-9366-a1c67a78d4dc"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 8,
                column: "UniqueGuId",
                value: new Guid("d03cd671-6d0f-4c92-a96d-1a9fd57c62fb"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 9,
                column: "UniqueGuId",
                value: new Guid("8a9bcfc5-adc0-4802-9739-262616781941"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 10,
                column: "UniqueGuId",
                value: new Guid("ec128131-1c82-4202-a949-4f12347223ac"));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 11,
                column: "UniqueGuId",
                value: new Guid("92408ff5-1745-46f0-bcb2-ccb41b297949"));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("60a0edc5-663d-49af-9710-327ab214e54d"));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("1973f54e-79c3-4846-b7b2-ad2b7556f616"));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("09c6ec68-4478-4881-855d-c3e8debfae4d"));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("8dea8006-d4a2-46e5-b6d7-7f39d92d9d4b"));

            migrationBuilder.UpdateData(
                table: "Uom",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("9140340c-0e8b-4d70-b4b7-5ed68685580c"));

            migrationBuilder.UpdateData(
                table: "Uom",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("9ee3ccc8-57f7-40de-acbb-249b10fd7bfc"));

            migrationBuilder.UpdateData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UniqueGuId",
                value: new Guid("54c97e63-4aab-4160-9c89-d808e07e7dc0"));

            migrationBuilder.UpdateData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniqueGuId",
                value: new Guid("50a6831e-9582-4b2f-a981-838f9c8bda43"));
        }
    }
}
