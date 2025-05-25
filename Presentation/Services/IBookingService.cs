using Presentation.Models;

namespace Presentation.Services
{
    public interface IBookingService
    {
        Task<BookingResult> CreateAsync(CreateBookingRequest req);
        Task<BookingResult<IEnumerable<Booking>>> GetAllBookingsAsync();
        Task<BookingResult<Booking?>> GetBookingByIdAsync(string id);
    }
}