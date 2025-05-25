namespace Presentation.Models;

public class Booking
{
    public string Id { get; set; } = null!;
    public string EventId { get; set; } = null!;
    public DateTime BookingDate { get; set; }
    public int TicketQuantity { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}
