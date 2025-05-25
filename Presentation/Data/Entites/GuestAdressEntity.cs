namespace Presentation.Data.Entites;

public class GuestAdressEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}