using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Data.Entites;

public class BookingEntity
{

    public string Id { get; set; } = null!;
    public string EventId { get; set; } = null!;
    public string? UserId { get; set; }
    public int TicketQuantity { get; set; } 
    public DateTime BookingDate { get; set; } 

    [ForeignKey(nameof(BookingGuest))]
    public string? GuestId { get; set; }
    public BookingGuestEntity? BookingGuest { get; set; }

}
