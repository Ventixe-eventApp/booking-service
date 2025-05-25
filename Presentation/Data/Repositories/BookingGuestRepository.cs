using Presentation.Data.Context;
using Presentation.Data.Entites;

namespace Presentation.Data.Repositories;

public class BookingGuestRepository(DataContext context) : BaseRepository<BookingGuestEntity>(context), IBookingGuestRepository
{
}
