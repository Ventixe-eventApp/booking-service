namespace Presentation.Models;

public class CreateBookingRequest
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string EventId { get; set; } = null!;
    public string? PackageId { get; set; }
    public string? UserId { get; set; }
    public int TicketQuantity { get; set; } = 1;

    public DateTime BookingDate { get; set; }
    public GuestDto? GuestInfo { get; set; }

}
public class GuestDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;

}
