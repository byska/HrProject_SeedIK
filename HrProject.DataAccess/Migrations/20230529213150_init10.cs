using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.DataAccess.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MersisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalisanSayisi = table.Column<int>(type: "int", nullable: false),
                    KurulusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SozlesmeBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SozlesmeBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktiflikDurumu = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionDay = table.Column<int>(type: "int", nullable: false),
                    IsFileRequired = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TC = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DismissalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvancePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvancePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvancePayments_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpenseImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PermissionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsActive", "Name", "NormalizedName" },
                values: new object[] { 1, "09d4c234-9f36-4838-9056-7ebe7a94de97", true, "Çalışan", null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Adres", "AktiflikDurumu", "CalisanSayisi", "CompanyName", "Email", "IsActive", "KurulusTarihi", "LogoImage", "MersisNo", "SozlesmeBaslangicTarihi", "SozlesmeBitisTarihi", "TelefonNo", "Unvan", "VergiNo" },
                values: new object[,]
                {
                    { 1, "Altunizade Sokak No : 5 ", true, 10, "Yasak Holding", "holdingyasak@hotmail.com", true, new DateTime(1990, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "dglaşsgas", "a001950190191534", new DateTime(1998, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2040, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "08508505050", "YASSAK", "1240120512" },
                    { 2, "Altunizade Sokak No : 5 ", true, 10, "Bilge Adam", "holdingyasak@hotmail.com", true, new DateTime(1990, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "dglaşsgas", "a001950190191565", new DateTime(1998, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2040, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "08508505050", "YASSAK", "1240120512" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Yönetim", true },
                    { 2, "Web", true },
                    { 3, "Ar-Ge", true }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "IsActive", "JobName" },
                values: new object[,]
                {
                    { 1, true, "Yazılım Mühendisi" },
                    { 2, true, "Veri Bilimci" },
                    { 3, true, "Yönetici" }
                });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "Gender", "IsActive", "IsFileRequired", "PermissionDay", "PermissionName" },
                values: new object[,]
                {
                    { 1, 2, true, false, 0, "Yıllık İzin < 1" },
                    { 2, 2, true, false, 14, "Yıllık İzin < 5" },
                    { 3, 2, true, false, 20, "Yıllık İzin > 5" },
                    { 4, 2, true, true, 20, "Mazeret" },
                    { 5, 0, true, true, 32, "Annelik" },
                    { 6, 1, true, true, 5, "Babalık İzni" },
                    { 7, 2, true, true, 3, "Ölüm İzni" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "BirthPlace", "CompanyID", "ConcurrencyStamp", "DepartmentID", "DismissalDate", "Email", "EmailConfirmed", "EmployeeImage", "FirstName", "Gender", "IsActive", "JobID", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondFirstName", "SecondLastName", "SecurityStamp", "StartDate", "TC", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "Altunizade", new DateTime(1998, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sakarya", 1, "7f01406d-d402-4b97-81f5-308450478c50", 2, null, "besteyasak@bilgeadamboost.com", false, "", "Beste", 0, true, 1, "Yasak", false, null, null, null, null, null, false, 60000, null, null, null, new DateTime(2010, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "651466416", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "BirthPlace", "CompanyID", "ConcurrencyStamp", "DepartmentID", "DismissalDate", "Email", "EmailConfirmed", "EmployeeImage", "FirstName", "Gender", "IsActive", "JobID", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondFirstName", "SecondLastName", "SecurityStamp", "StartDate", "TC", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "Beşiktaş", new DateTime(1980, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antalya", 2, "2520f276-9d6c-465a-99ee-b9944cdfdf05", 3, null, "anilirmak@bilgeadamboost.com", false, "", "Alp", 1, true, 2, "Irmak", false, null, null, null, null, null, false, 20000, null, null, null, new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "2737373", false, null });

            migrationBuilder.InsertData(
                table: "AdvancePayments",
                columns: new[] { "Id", "Amount", "AppUserID", "Currency", "Description", "IsActive", "ReplyDate", "RequestDate", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1500.0, 1, 0, "ihtiyaç", true, null, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 2, 15000.0, 2, 0, "ihtiyaç", true, null, new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 },
                    { 3, 1500.0, 1, 0, "ihtiyaç", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3561), 1, 0 },
                    { 4, 10000.0, 2, 2, "Konaklama", true, null, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 5, 2500.0, 1, 1, "seyahat", true, null, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 6, 500.0, 2, 0, "ihtiyaç", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3567), 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "AppUserID", "Currency", "ExpenseImage", "IsActive", "ReplyDate", "RequestDate", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1500.0, 1, 1, "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3581), 2, 1 },
                    { 2, 2500.0, 1, 0, "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3585), 1, 0 },
                    { 3, 500.0, 1, 2, "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3586), 0, 2 },
                    { 4, 500.0, 2, 0, "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3619), 0, 1 },
                    { 5, 200.0, 2, 2, "", true, null, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "AppUserID", "EndDate", "File", "IsActive", "ReplyDate", "RequestDate", "StartDate", "Status", "TypeId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3525), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 6 },
                    { 2, 1, new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3527), new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 3, 1, new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3529), new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 4, 2, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3530), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7 },
                    { 5, 2, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3532), new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7 },
                    { 6, 1, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3534), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 7, 2, new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, new DateTime(2023, 5, 30, 0, 31, 50, 502, DateTimeKind.Local).AddTicks(3535), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvancePayments_AppUserID",
                table: "AdvancePayments",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyID",
                table: "AspNetUsers",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobID",
                table: "AspNetUsers",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AppUserID",
                table: "Expenses",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_AppUserID",
                table: "Permissions",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_TypeId",
                table: "Permissions",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvancePayments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PermissionType");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
