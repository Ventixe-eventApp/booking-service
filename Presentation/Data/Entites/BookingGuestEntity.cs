using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Data.Entites;

public class BookingGuestEntity
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey(nameof(GuestAddress))]
    public string? GuestAddressId { get; set; } 
    public GuestAdressEntity? GuestAddress { get; set; } 
}
