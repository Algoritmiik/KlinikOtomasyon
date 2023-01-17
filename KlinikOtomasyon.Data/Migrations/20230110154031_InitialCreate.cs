using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlinikOtomasyon.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceOf = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PriceAmount = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
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
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ComingFrom = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HowFindUs = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Surgeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SurgeryPrice = table.Column<int>(type: "int", nullable: false),
                    HospitalPrice = table.Column<int>(type: "int", nullable: false),
                    SurgeryPriceCurrency = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HospitalPriceCurrency = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HospitalDay = table.Column<int>(type: "int", nullable: false),
                    HotelDay = table.Column<int>(type: "int", nullable: false),
                    IsExtra = table.Column<bool>(type: "bit", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surgeries_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Massages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WherePerformed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Massages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Massages_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    WhatFor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsCash = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PerformedSurgeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurgeryId = table.Column<int>(type: "int", nullable: true),
                    Epicrisis = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TakenFatAmount = table.Column<int>(type: "int", nullable: false),
                    GivenFatAmount = table.Column<int>(type: "int", nullable: false),
                    ImplantSize = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformedSurgeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformedSurgeries_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PerformedSurgeries_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PerformedSurgeries_Surgeries_SurgeryId",
                        column: x => x.SurgeryId,
                        principalTable: "Surgeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MassagesEmployees",
                columns: table => new
                {
                    MassageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassagesEmployees", x => new { x.MassageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MassagesEmployees_Massages_MassageId",
                        column: x => x.MassageId,
                        principalTable: "Massages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MassagesEmployees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "60403a2a-b007-4da1-9f1d-5c618f84bd01", "Admin", "ADMIN" },
                    { 2, "e9baa8a9-b50e-4ed0-884b-73b42627d623", "Nurse", "NURSE" },
                    { 3, "89b4b413-a6b0-469e-a00c-4027ea617ef7", "Manager", "MANAGER" },
                    { 4, "c4c958df-deba-439f-9642-c20447a51728", "Sales", "SALES" },
                    { 5, "ce76b33b-ea08-4f76-a2f5-dc6e1f24c597", "Doctor", "DOCTOR" },
                    { 6, "a3af6a75-99cf-4c22-b6da-ca80fb71351d", "Masseuse", "MASSEUSE" },
                    { 7, "4a5e08bf-05b6-4ae3-bf14-aec40ba6c29f", "Translator", "TRANSLATOR" }
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 778, DateTimeKind.Local).AddTicks(8640), true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 778, DateTimeKind.Local).AddTicks(8640), "Trioklinik", "İlk klinik. FluentAPI ile oluşturulmuştur." });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Currency", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "PriceAmount", "PriceOf" },
                values: new object[] { 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(7250), "Euro", true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(7250), "İlk fiyat. FluentAPI ile oluşturulmuştur.", 80, "Hotel 1 Kişilik Standart Oda" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "ClinicId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1360), true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1370), "Hemşire", "İlk Hemşire Departmanı. FluentAPI ile oluşturulmuştur." },
                    { 2, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1370), true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1370), "Satış", "İlk Satış Departmanı. FluentAPI ile oluşturulmuştur." },
                    { 3, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1380), true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1380), "Tercüman", "İlk Tercüman Departmanı. FluentAPI ile oluşturulmuştur." },
                    { 4, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1390), true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1390), "Masaj", "İlk Masaj Departmanı. FluentAPI ile oluşturulmuştur." },
                    { 5, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1390), true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1400), "Hekim", "İlk Hekim Departmanı. FluentAPI ile oluşturulmuştur." },
                    { 6, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1400), true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(1400), "Yönetim", "İlk Yönetim Departmanı. FluentAPI ile oluşturulmuştur." }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "ClinicId", "ComingFrom", "CreatedByName", "CreatedDate", "HowFindUs", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note", "Surname" },
                values: new object[] { 1, 1, "Avustralya", "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(9050), "Instagram", true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(9050), "Fake", "İlk Hasta. FluentAPI ile oluşturulmuştur.", "Patient" });

            migrationBuilder.InsertData(
                table: "Surgeries",
                columns: new[] { "Id", "ClinicId", "CreatedByName", "CreatedDate", "HospitalDay", "HospitalPrice", "HospitalPriceCurrency", "HotelDay", "IsActive", "IsDeleted", "IsExtra", "ModifiedByName", "ModifiedDate", "Name", "Note", "SurgeryPrice", "SurgeryPriceCurrency" },
                values: new object[,]
                {
                    { 1, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9800), 2, 1000, "Euro", 4, true, false, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9800), "BBL (Brazilian Butt Lift)", "Örnek Ameliyat. FluentAPI ile oluşturulmuştur.", 2440, "Euro" },
                    { 2, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9800), 2, 1100, "Euro", 5, true, false, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9810), "Rhinoplasty", "Örnek Ameliyat. FluentAPI ile oluşturulmuştur.", 2310, "Euro" },
                    { 3, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9810), 1, 920, "Euro", 2, true, false, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9820), "Chin Implant", "Örnek Ameliyat. FluentAPI ile oluşturulmuştur.", 2050, "Euro" },
                    { 4, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9820), 2, 2000, "Euro", 5, true, false, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9820), "Facelift", "Örnek Ameliyat. FluentAPI ile oluşturulmuştur.", 2810, "Euro" },
                    { 5, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9830), 0, 0, "Euro", 0, true, false, true, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(9830), "Kol Ekstra Bölge", "Örnek Ameliyat. FluentAPI ile oluşturulmuştur.", 300, "Euro" }
                });

            migrationBuilder.InsertData(
                table: "Massages",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "PatientId", "WherePerformed" },
                values: new object[] { 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(6660), true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 779, DateTimeKind.Local).AddTicks(6660), "İlk Masaj. FluentAPI ile oluşturulmuştur.", 1, "Otel" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Currency", "IsActive", "IsCash", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "PatientId", "Price", "WhatFor" },
                values: new object[] { 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(1530), "Euro", true, true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(1540), "İlk Ödeme. FluentAPI ile oluşturulmuştur.", 1, 3500, "Ameliyat" });

            migrationBuilder.InsertData(
                table: "PerformedSurgeries",
                columns: new[] { "Id", "ClinicId", "CreatedByName", "CreatedDate", "Epicrisis", "GivenFatAmount", "ImplantSize", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "PatientId", "SurgeryId", "TakenFatAmount" },
                values: new object[] { 1, 1, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(5990), "...", 800, 0, true, false, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 780, DateTimeKind.Local).AddTicks(5990), "İlk Yapılan Ameliyat. FluentAPI ile oluşturulmuştur.", 1, 1, 2500 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedByName", "CreatedDate", "DepartmentId", "Email", "EmailConfirmed", "IdentityNumber", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedByName", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "Note", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "5aa693e9-60cf-4a0d-ae80-4661fa0f514c", "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 784, DateTimeKind.Local).AddTicks(7380), 3, "metearslan@deneme.com", true, "12345678912", true, false, false, null, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 784, DateTimeKind.Local).AddTicks(7380), "Mete", "metearslan@deneme.com", "MARSLAN", "İlk tercüman. FluentAPI ile oluşturulmuştur.", "AQAAAAEAACcQAAAAEBrL2BgKNcQNEb0FTebpM/+ZqI6qTapOHF/vjtRwPlfFZRF3kpAAsRfyuuiOOZ9zBQ==", "905344236576", false, "", "Arslan", false, "marslan" },
                    { 2, 0, "39e24d5f-6f13-4899-8e5c-998a39339328", "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 787, DateTimeKind.Local).AddTicks(5400), 1, "nurcanozmen@deneme.com", true, "12345678912", true, false, false, null, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 787, DateTimeKind.Local).AddTicks(5400), "Nurcan", "nurcanozmen@deneme.com", "NOZMEN", "İlk hemşire. FluentAPI ile oluşturulmuştur.", "AQAAAAEAACcQAAAAEFvZ8Y4LnmXfzYISfDxF82uXvL1DJSWDhjlXA7PnXg2veB/Tq9TvT4Mf9IJ+LGX1SQ==", "905344236597", false, "", "Özmen", false, "nozmen" },
                    { 3, 0, "73b1e0d1-17ad-4ee4-a9fd-7508fd5b5bfe", "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 790, DateTimeKind.Local).AddTicks(3450), 2, "karinsarkli@deneme.com", true, "12345678912", true, false, false, null, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 790, DateTimeKind.Local).AddTicks(3450), "Karin", "karinsarkli@deneme.com", "KSARKLI", "İlk satış elemanı. FluentAPI ile oluşturulmuştur.", "AQAAAAEAACcQAAAAEJyOw2QofB575oEnpAIF5ocWTMnkU2HvfcZ+b4nOD0wyOW94yESGXuCx2dSdUpEEpw==", "905344236598", false, "", "Şarklı", false, "ksarkli" },
                    { 4, 0, "db7a6c60-fa7b-49ff-b597-1ec8d8c33889", "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 793, DateTimeKind.Local).AddTicks(1840), 4, "betulkucukozen@deneme.com", true, "12345678912", true, false, false, null, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 793, DateTimeKind.Local).AddTicks(1850), "Betül", "betulkucukozen@deneme.com", "BKUCUKOZEN", "İlk masaj elemanı. FluentAPI ile oluşturulmuştur.", "AQAAAAEAACcQAAAAEMAV0p1DscaIkjZsPkfvy8IYRaQ4aWwePQ0XRoHijjX7FEXkwiH483pP482ZpuuvOg==", "905344236599", false, "", "Küçüközen", false, "bkucukozen" },
                    { 5, 0, "12b9efb6-3220-40c2-a49c-a71a3e424b79", "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 795, DateTimeKind.Local).AddTicks(9950), 5, "cagdasorman@deneme.com", true, "12345678912", true, false, false, null, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 795, DateTimeKind.Local).AddTicks(9950), "Çağdaş", "cagdasorman@deneme.com", "CORMAN", "İlk hekim. FluentAPI ile oluşturulmuştur.", "AQAAAAEAACcQAAAAEPzbLjEFPXVCkxMERCz5vqwU0vzDS8frX75iKn+Xqjc9wDFk2YsV3RDgyjFYeBNoXg==", "905344236595", false, "", "Orman", false, "corman" },
                    { 6, 0, "fc6a8ea1-129a-4697-b1ed-0a6644e7a604", "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 798, DateTimeKind.Local).AddTicks(8020), 6, "kemalogulcanozsicak@deneme.com", true, "12345678912", true, false, false, null, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 798, DateTimeKind.Local).AddTicks(8020), "Kemal Oğulcan", "kemalogulcanozsicak@deneme.com", "KOOZSICAK", "İlk yönetici. FluentAPI ile oluşturulmuştur.", "AQAAAAEAACcQAAAAECQJA1xKmzi+9di4YTRqlcnGXcSKPunO4v74F7Bf8dJNRKzzqX4Vg2TCmmWmyFQM+g==", "905344236594", false, "", "Özsıcak", false, "koozsicak" },
                    { 7, 0, "4a27c982-c50c-4a5b-a9c2-b623eca8cd9d", "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 801, DateTimeKind.Local).AddTicks(6260), 6, "mertcanaslan@deneme.com", true, "12345678912", true, false, false, null, "Admin", new DateTime(2023, 1, 10, 18, 40, 30, 801, DateTimeKind.Local).AddTicks(6260), "Mertcan", "mertcanaslan@deneme.com", "MASLAN", "İlk yönetici. FluentAPI ile oluşturulmuştur.", "AQAAAAEAACcQAAAAEMlgLYnwClPxP8u9R2dsd5sS/OzUxpZHHnmLRlx5ihYq7uzp4kcS6rzjLqI2FvtpYQ==", "905344236594", false, "", "Aslan", false, "maslan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 7, 1 },
                    { 2, 2 },
                    { 4, 3 },
                    { 6, 4 },
                    { 5, 5 },
                    { 3, 6 },
                    { 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "MassagesEmployees",
                columns: new[] { "MassageId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 }
                });

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
                name: "IX_Departments_ClinicId",
                table: "Departments",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Massages_PatientId",
                table: "Massages",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MassagesEmployees_UserId",
                table: "MassagesEmployees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ClinicId",
                table: "Patients",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PatientId",
                table: "Payments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedSurgeries_ClinicId",
                table: "PerformedSurgeries",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedSurgeries_PatientId",
                table: "PerformedSurgeries",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedSurgeries_SurgeryId",
                table: "PerformedSurgeries",
                column: "SurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_ClinicId",
                table: "Surgeries",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "MassagesEmployees");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PerformedSurgeries");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Massages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Surgeries");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Clinics");
        }
    }
}
