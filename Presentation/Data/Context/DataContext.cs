using Microsoft.EntityFrameworkCore;
using Presentation.Data.Entites;

namespace Presentation.Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    public DbSet<BookingEntity> Bookings { get; set; }
    public DbSet<BookingGuestEntity> BookingGuests { get; set; }
    public DbSet<GuestAdressEntity> GuestAdresses { get; set; }
    
}
