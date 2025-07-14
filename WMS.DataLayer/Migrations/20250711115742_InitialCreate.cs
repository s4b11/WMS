using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Addr1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Addr2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Pin = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CpName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LstRegnno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LstRegndate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CstRegnno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CstRegndate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StRegnno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StRegndate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    TransExistFlag = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Addr1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Addr2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Pin = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    ContactPerson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPMobile = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmailID = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPEmailID = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    URL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BaseCurr = table.Column<int>(type: "integer", nullable: false),
                    ECCNO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TINNO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TINDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CSTNO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CSTDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    _3PLFlag = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true, defaultValue: "N"),
                    TransExistFlag = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true, defaultValue: "N"),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ImageName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Addr1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Addr2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Pin = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EmailID = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPEmailID = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPMobile = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    URL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BaseCurr = table.Column<int>(type: "integer", nullable: false),
                    ECCNO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TINNO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TINDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CSTNO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CSTDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    TransExistFlag = table.Column<char>(type: "character(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    Class = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Method = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ErrorMessage = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    ActionName = table.Column<string>(type: "text", nullable: false),
                    ControllerName = table.Column<string>(type: "text", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeqErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Seed = table.Column<int>(type: "integer", nullable: false),
                    Incr = table.Column<int>(type: "integer", nullable: false),
                    Curval = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeqErrorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Short = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TransExistFlag = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FDType = table.Column<char>(type: "character(1)", nullable: false),
                    Addr1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Addr2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Pin = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EmailID = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPEmailID = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPMobile = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BaseCurr = table.Column<int>(type: "integer", nullable: false),
                    ECCNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TINNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TINDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CSTNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CSTDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    TransExist = table.Column<char>(type: "character(1)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UniqueGuId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carrier",
                columns: new[] { "Id", "Addr1", "Addr2", "City", "CountryId", "CpName", "CreatedBy", "CreatedDate", "CstRegndate", "CstRegnno", "CustomerId", "Email", "IsDeleted", "LstRegndate", "LstRegnno", "Mobile", "ModifiedBy", "ModifiedDate", "Name", "Phone", "Pin", "StRegndate", "StRegnno", "StateId", "TransExistFlag", "Type", "UniqueGuId" },
                values: new object[,]
                {
                    { 1, "123 Skyline Rd", "Suite 400", "Mumbai", 101, "John Doe", 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "CST54321", 1001, "contact@expresslogistics.com", false, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "LST12345", "9876543210", 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Express Logistics", "02212345678", "400001", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "ST11111", 27, "N", "Air", new Guid("4162c02d-a287-4f2f-a0c3-f50e88951719") },
                    { 2, "456 NH Road", null, "Chennai", 101, "Jane Smith", 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "CST09876", 1002, "support@cargomovers.in", false, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "LST67890", "9123456780", 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Cargo Movers", "04487654321", "600001", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "ST22222", 33, "Y", "Road", new Guid("5acf9f29-dbff-4c84-a582-2959fa429e01") }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Addr1", "Addr2", "BaseCurr", "CPEmailID", "CPMobile", "CSTDATE", "CSTNO", "City", "Code", "ContactPerson", "CountryId", "CreatedBy", "CreatedDate", "ECCNO", "EmailID", "Image", "ImageName", "ImagePath", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Phone", "Pin", "StateId", "TINDATE", "TINNO", "TransExistFlag", "URL", "UniqueGuId", "UserID", "_3PLFlag" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "Suite 500", 1, "john.smith@abccorp.com", "+1-917-555-5678", new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "CST456789", "New York", "ABC001", "John Smith", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EC12345678", "info@abccorp.com", new byte[0], "abc-corp.jpg", "/images/companies/abc-corp.jpg", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC Corporation", "+1-212-555-1234", "10001", 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "TIN987654", "Y", "www.abccorp.com", new Guid("24c8090d-3c70-462a-a318-4a9090dca96d"), 1, "N" },
                    { 2, "456 Commerce Road", null, 1, "sarah.j@xyzlogistics.com", "+1-312-555-7891", null, null, "Chicago", "XYZ002", "Sarah Johnson", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "contact@xyzlogistics.com", new byte[0], "xyz-logistics.jpg", "/images/companies/xyz-logistics.jpg", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XYZ Logistics", "+1-312-555-7890", "60601", 2, null, null, "N", "www.xyzlogistics.com", new Guid("c7cd4c4c-1881-48ff-ae3b-850a50b8c504"), 1, "Y" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryCode", "CountryName", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "UniqueGuId" },
                values: new object[,]
                {
                    { 1, "AF", "Afghanistan", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fd86f784-93de-4bfb-a8db-c7e09d70ed9e") },
                    { 2, "AL", "Albania", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de8bdd82-fb43-4ba2-a877-faf451ba9f51") },
                    { 3, "DZ", "Algeria", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a79fd19e-0f00-45c0-8c2e-7fa91bd97175") },
                    { 4, "AD", "Andorra", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40266f15-1b92-4586-9c7c-730b63781b37") },
                    { 5, "AO", "Angola", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a13c656-6e2e-419b-b9ad-c4c9ba6604dc") },
                    { 6, "AG", "Antigua and Barbuda", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ef2d48f-651f-4b34-a961-30eb9c802e58") },
                    { 7, "AR", "Argentina", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e81dd9fe-a12a-4fa0-a0be-f8e1055ea24e") },
                    { 8, "AM", "Armenia", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2c9aa1dc-32a4-4ab6-8f50-a84fd666d65e") },
                    { 9, "AU", "Australia", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("be8c94f5-4660-4a77-aca6-c146c87ca81f") },
                    { 10, "AT", "Austria", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de0c8df3-dc16-4661-9f4d-86d96ee6782d") },
                    { 11, "AZ", "Azerbaijan", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b91e3f50-0934-4747-8f84-0b4db2602276") }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code", "CountryId", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "UniqueGuId" },
                values: new object[,]
                {
                    { 1, "USD", 1, 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "US Dollar", new Guid("9994a29d-edb8-49f9-a35d-088571425165") },
                    { 2, "EUR", 2, 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, 0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Euro", new Guid("a99743a7-67a4-4729-bbf8-459523cf87a6") }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Addr1", "Addr2", "BaseCurr", "CPEmailID", "CPMobile", "CSTDATE", "CSTNO", "City", "Code", "CompanyId", "ContactPerson", "CountryId", "CreatedBy", "CreatedDate", "ECCNO", "EmailID", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Phone", "Pin", "StateId", "TINDATE", "TINNO", "TransExistFlag", "URL", "UniqueGuId", "UserID" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Suite 400", 1, "john.doe@acmecorp.com", "9876543210", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "CST123456", "New York", "ACM001", 1, "John Doe", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ECC123456", "info@acmecorp.com", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acme Corp", "1234567890", "10001", 10, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "TIN987654", 'N', "https://acmecorp.com", new Guid("eef456a9-0481-4db5-af5b-3fbdaf5c2d44"), 1 },
                    { 2, "456 Market Ave", null, 2, "jane.smith@betaind.com", "8765432109", null, null, "Los Angeles", "BET002", 1, "Jane Smith", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "contact@betaind.com", false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beta Industries", "2345678901", "90001", 5, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "TIN654321", 'Y', "https://betaind.com", new Guid("84f1a1e5-bcba-4268-93fd-970b17e58e13"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Uom",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Short", "TransExistFlag", "UniqueGuId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Kilogram", "kg", "Y", new Guid("3b65c5ce-e0c0-4900-875f-cfe0ae1a12c7") },
                    { 2, 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Liter", "L", "Y", new Guid("70273171-4a0c-4118-b1c2-688403d6aa51") }
                });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "Id", "Addr1", "Addr2", "BaseCurr", "CPEmailID", "CPMobile", "CSTDate", "CSTNo", "City", "Code", "ContactPerson", "CountryId", "CreatedBy", "CreatedDate", "CustomerId", "ECCNo", "EmailID", "FDType", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Phone", "Pin", "StateId", "TINDate", "TINNo", "TransExist", "UniqueGuId", "Url", "UserID" },
                values: new object[,]
                {
                    { 1, "123 International Road", "Suite 501", 1, "j.doe@gtc.com", "+1-212-555-2000", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "CST456789", "New York", "GTC001", "John Doe", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1001, "ECC123456", "info@gtc.com", 'F', false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Trade Co.", "+1-212-555-1000", "10001", 10, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "TIN789012", 'N', new Guid("da2c7bd3-daa1-442d-a0df-1ba1c29f26d4"), "https://www.gtc.com", 1 },
                    { 2, "456 Local Street", null, 2, "anita.rao@dsl.in", "+91-9876543210", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "CST987654", "Mumbai", "DSL002", "Anita Rao", 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1002, "ECC654321", "support@dsl.in", 'D', false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domestic Supplies Ltd.", "+91-22-555-3000", "400001", 21, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "TIN210987", 'Y', new Guid("03453b94-f32a-489d-85a3-0fb75348d46c"), "https://www.dsl.in", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrier");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "ExceptionLog");

            migrationBuilder.DropTable(
                name: "SeqErrorLog");

            migrationBuilder.DropTable(
                name: "Uom");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
