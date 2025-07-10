using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airbnb.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Listing");

            migrationBuilder.EnsureSchema(
                name: "Rule");

            migrationBuilder.CreateTable(
                name: "Amenity",
                schema: "Listing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                schema: "Rule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescriptionTemplate = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterDefinition",
                schema: "Rule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RuleCatalogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterDefinition_Catalog_RuleCatalogId",
                        column: x => x.RuleCatalogId,
                        principalSchema: "Rule",
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                schema: "Listing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckInTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CheckOutTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MinimumNights = table.Column<int>(type: "int", nullable: false),
                    MaximumNights = table.Column<int>(type: "int", nullable: false),
                    BlockedDatesJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "Listing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IsCoverPhoto = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                schema: "Listing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Bedrooms = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Beds = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                schema: "Rule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RuleCatalogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParametersJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listing_Catalog_RuleCatalogId",
                        column: x => x.RuleCatalogId,
                        principalSchema: "Rule",
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listing_Listing_ListingId",
                        column: x => x.ListingId,
                        principalSchema: "Listing",
                        principalTable: "Listing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Listing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Listing_Id",
                        column: x => x.Id,
                        principalSchema: "Listing",
                        principalTable: "Listing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                schema: "Listing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CleaningFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    SecurityDeposit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    WeeklyDiscount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    MonthlyDiscount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    ExtraGuestFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ListingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Listing_ListingId",
                        column: x => x.ListingId,
                        principalSchema: "Listing",
                        principalTable: "Listing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availability_ListingId",
                schema: "Listing",
                table: "Availability",
                column: "ListingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ListingId",
                schema: "Listing",
                table: "Images",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_LocationId",
                schema: "Listing",
                table: "Listing",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ListingId",
                schema: "Rule",
                table: "Listing",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_RuleCatalogId",
                schema: "Rule",
                table: "Listing",
                column: "RuleCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Id",
                schema: "Listing",
                table: "Location",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDefinition_RuleCatalogId",
                schema: "Rule",
                table: "ParameterDefinition",
                column: "RuleCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ListingId",
                schema: "Listing",
                table: "Price",
                column: "ListingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Listing_ListingId",
                schema: "Listing",
                table: "Availability",
                column: "ListingId",
                principalSchema: "Listing",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Listing_ListingId",
                schema: "Listing",
                table: "Images",
                column: "ListingId",
                principalSchema: "Listing",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Location_LocationId",
                schema: "Listing",
                table: "Listing",
                column: "LocationId",
                principalSchema: "Listing",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Listing_Id",
                schema: "Listing",
                table: "Location");

            migrationBuilder.DropTable(
                name: "Amenity",
                schema: "Listing");

            migrationBuilder.DropTable(
                name: "Availability",
                schema: "Listing");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "Listing");

            migrationBuilder.DropTable(
                name: "Listing",
                schema: "Rule");

            migrationBuilder.DropTable(
                name: "ParameterDefinition",
                schema: "Rule");

            migrationBuilder.DropTable(
                name: "Price",
                schema: "Listing");

            migrationBuilder.DropTable(
                name: "Catalog",
                schema: "Rule");

            migrationBuilder.DropTable(
                name: "Listing",
                schema: "Listing");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Listing");
        }
    }
}
