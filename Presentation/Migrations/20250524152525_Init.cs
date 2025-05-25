using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentation.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestAdresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestAdresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingGuests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestAddressId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingGuests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingGuests_GuestAdresses_GuestAddressId",
                        column: x => x.GuestAddressId,
                        principalTable: "GuestAdresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketQuatity = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingGuests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "BookingGuests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingGuests_GuestAddressId",
                table: "BookingGuests",
                column: "GuestAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingGuests");

            migrationBuilder.DropTable(
                name: "GuestAdresses");
        }
    }
}
