using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyPropertyManagement.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "BUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Report = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_BUs_BuId",
                        column: x => x.BuId,
                        principalTable: "BUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatCodes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatCodes_BUs_BuId",
                        column: x => x.BuId,
                        principalTable: "BUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatCodeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_SeatCodes_SeatCodeId",
                        column: x => x.SeatCodeId,
                        principalTable: "SeatCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7b79fd81-4b3d-4ae1-b426-ae0d0ac8f0d2"), "49d91a48-ffdb-404c-8380-72a27606cc02", "Employee", "EMPLOYEE" },
                    { new Guid("2ffdcb9b-c25d-4dfb-96db-c257f4cbdd28"), "bf22dfa0-fb11-4927-8461-2c1c5313fb12", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2bc6912e-3848-4882-861c-8ba7f54fdcd0"), 0, "59ab5f4a-c3da-4f16-a3e1-4ec10b6c0e86", null, false, false, null, null, null, null, null, false, null, false, "Employee1" });

            migrationBuilder.InsertData(
                table: "BUs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d1e604eb-6eca-4458-b731-5504f522f803"), "Unit 1" },
                    { new Guid("098675b5-5f60-4ac0-bcf8-581d48e79ff7"), "Unit 2" },
                    { new Guid("aa1df8d7-7c94-4168-9bfe-54dd3356f656"), "Unit 3" },
                    { new Guid("7cc88bcf-5db7-462c-bfcf-3e941d2eff96"), "Unit 4" },
                    { new Guid("d3ef7298-0059-42f5-90fa-12f4549ed0db"), "Unit 5" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ba9ec1e0-676d-4a37-9ff2-fee3641cfff0"), "Screen" },
                    { new Guid("b263ae2c-f981-406e-a1c9-2661e1653979"), "Keyboard" },
                    { new Guid("59253a87-9db9-42ed-8aef-5b06aaa7c52b"), "Mouse" },
                    { new Guid("e240e347-6044-4643-8061-2ec2f124165b"), "Chair" },
                    { new Guid("3eabb0c3-beec-493e-9a9d-6aeaca1969df"), "Table" }
                });

            migrationBuilder.InsertData(
                table: "SeatCodes",
                columns: new[] { "Id", "BuId" },
                values: new object[,]
                {
                    { "11.05.058", new Guid("d1e604eb-6eca-4458-b731-5504f522f803") },
                    { "11.05.059", new Guid("d1e604eb-6eca-4458-b731-5504f522f803") },
                    { "11.05.060", new Guid("d1e604eb-6eca-4458-b731-5504f522f803") },
                    { "11.05.061", new Guid("d1e604eb-6eca-4458-b731-5504f522f803") },
                    { "11.05.062", new Guid("d1e604eb-6eca-4458-b731-5504f522f803") }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "CategoryId", "Info", "SeatCodeId" },
                values: new object[,]
                {
                    { new Guid("08983801-6db7-40ad-ac98-070945a8ef3c"), new Guid("ba9ec1e0-676d-4a37-9ff2-fee3641cfff0"), null, "11.05.058" },
                    { new Guid("5539bd07-3c6c-46df-b72d-d20a6ebd8f7a"), new Guid("59253a87-9db9-42ed-8aef-5b06aaa7c52b"), null, "11.05.062" },
                    { new Guid("7f77d7a6-88d0-41af-9a8c-8b784b562417"), new Guid("b263ae2c-f981-406e-a1c9-2661e1653979"), null, "11.05.062" },
                    { new Guid("7fe38c3a-ce80-4a74-9a58-e8ea1c776af8"), new Guid("ba9ec1e0-676d-4a37-9ff2-fee3641cfff0"), null, "11.05.062" },
                    { new Guid("c65add1d-9405-498a-81af-4a43a7a3ad3b"), new Guid("3eabb0c3-beec-493e-9a9d-6aeaca1969df"), null, "11.05.061" },
                    { new Guid("3ac45609-f51e-4deb-b284-278d3a0cd122"), new Guid("e240e347-6044-4643-8061-2ec2f124165b"), null, "11.05.061" },
                    { new Guid("0f48d9a8-d140-43df-8311-c0e4cad567d5"), new Guid("59253a87-9db9-42ed-8aef-5b06aaa7c52b"), null, "11.05.061" },
                    { new Guid("a222bf17-af85-4d51-b7df-2852f5ed2874"), new Guid("b263ae2c-f981-406e-a1c9-2661e1653979"), null, "11.05.061" },
                    { new Guid("5ded5c64-c347-4920-82e7-4ed6167206e9"), new Guid("ba9ec1e0-676d-4a37-9ff2-fee3641cfff0"), null, "11.05.061" },
                    { new Guid("b876724c-563c-4fbd-bfe8-aff8aedd92d3"), new Guid("3eabb0c3-beec-493e-9a9d-6aeaca1969df"), null, "11.05.060" },
                    { new Guid("6306768f-31d1-4dbd-a259-79acd342f12a"), new Guid("e240e347-6044-4643-8061-2ec2f124165b"), null, "11.05.060" },
                    { new Guid("758bbd80-8f06-4bb7-81fc-86af90edf925"), new Guid("e240e347-6044-4643-8061-2ec2f124165b"), null, "11.05.062" },
                    { new Guid("375c3d45-5b72-4a44-a22a-8986ebf667cf"), new Guid("59253a87-9db9-42ed-8aef-5b06aaa7c52b"), null, "11.05.060" },
                    { new Guid("b310b6af-e3fd-4b31-bd75-544dde0ba9fc"), new Guid("ba9ec1e0-676d-4a37-9ff2-fee3641cfff0"), null, "11.05.060" },
                    { new Guid("5b763a4d-a34e-4728-9d18-4a3597722e00"), new Guid("3eabb0c3-beec-493e-9a9d-6aeaca1969df"), null, "11.05.059" },
                    { new Guid("cccd7ece-8015-43b4-b221-a0054f8147fe"), new Guid("e240e347-6044-4643-8061-2ec2f124165b"), null, "11.05.059" },
                    { new Guid("c4f89e0c-6a70-498c-83cf-4b5ac85847b3"), new Guid("59253a87-9db9-42ed-8aef-5b06aaa7c52b"), null, "11.05.059" },
                    { new Guid("93095204-ed3d-4c46-94a5-20de97967407"), new Guid("b263ae2c-f981-406e-a1c9-2661e1653979"), null, "11.05.059" },
                    { new Guid("e25e5986-efbe-4620-b036-91266982540b"), new Guid("ba9ec1e0-676d-4a37-9ff2-fee3641cfff0"), null, "11.05.059" },
                    { new Guid("a26564ba-6b2a-420e-bee2-860ca211d812"), new Guid("3eabb0c3-beec-493e-9a9d-6aeaca1969df"), null, "11.05.058" },
                    { new Guid("150b4807-35b7-45b4-a154-6482a5987c41"), new Guid("e240e347-6044-4643-8061-2ec2f124165b"), null, "11.05.058" },
                    { new Guid("45442fc4-1ae7-433f-acde-1d554c6a8c08"), new Guid("59253a87-9db9-42ed-8aef-5b06aaa7c52b"), null, "11.05.058" },
                    { new Guid("15898832-d82e-4868-a289-be6183739b73"), new Guid("b263ae2c-f981-406e-a1c9-2661e1653979"), null, "11.05.058" },
                    { new Guid("81242aa5-e9ec-472e-9eae-20681d7b804a"), new Guid("b263ae2c-f981-406e-a1c9-2661e1653979"), null, "11.05.060" },
                    { new Guid("f9cbfb03-603a-4440-8b6c-7b3d5092d330"), new Guid("3eabb0c3-beec-493e-9a9d-6aeaca1969df"), null, "11.05.062" }
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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BuId",
                table: "Inventories",
                column: "BuId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UserId",
                table: "Inventories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CategoryId",
                table: "Properties",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SeatCodeId",
                table: "Properties",
                column: "SeatCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatCodes_BuId",
                table: "SeatCodes",
                column: "BuId");
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
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SeatCodes");

            migrationBuilder.DropTable(
                name: "BUs");
        }
    }
}
