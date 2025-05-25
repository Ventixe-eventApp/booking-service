using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentation.Migrations
{
    /// <inheritdoc />
    public partial class RenameTicketQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketQuatity",
                table: "Bookings",
                newName: "TicketQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketQuantity",
                table: "Bookings",
                newName: "TicketQuatity");
        }
    }
}
