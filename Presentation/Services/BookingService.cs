using Azure.Core;
using Microsoft.Extensions.Logging;
using Presentation.Data.Entites;
using Presentation.Data.Repositories;
using Presentation.Models;

namespace Presentation.Services;

public class BookingService(IBookingRepository bookingRepository, IBookingGuestRepository guestRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;

    private readonly IBookingGuestRepository _guestRepository = guestRepository;

  
      public async Task<BookingResult> CreateAsync(CreateBookingRequest req)
      {
        if (string.IsNullOrEmpty(req.UserId) && req.GuestInfo == null)
        {
            return new BookingResult
            {
                Succeeded = false,
                Error = "Required fields are missing."
            };
        }

        try
        {
            string? guestId = null;

       
            if (req.GuestInfo != null)
            {
                var guest = new BookingGuestEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = req.GuestInfo.FirstName,
                    LastName = req.GuestInfo.LastName,
                    Email = req.GuestInfo.Email,
                    PhoneNumber = req.GuestInfo.PhoneNumber,
                    GuestAddress = new GuestAdressEntity
                    {
                        Street = req.GuestInfo.Street,
                        PostalCode = req.GuestInfo.PostalCode,
                        City = req.GuestInfo.City,
                        Country = req.GuestInfo.Country
                    }
                };

                await _guestRepository.CreateAsync(guest);
                guestId = guest.Id;
            }

           
            var booking = new BookingEntity
            {
                Id = req.Id,
                EventId = req.EventId,
                PackageId = req.PackageId,
                UserId = req.UserId,
                BookingDate = DateTime.Now,
                TicketQuantity = req.TicketQuantity,
                GuestId = guestId
            };

            var result = await _bookingRepository.CreateAsync(booking);

            return result.Succeeded
                 ? new BookingResult { Succeeded = true }
                 : new BookingResult { Succeeded = false, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new BookingResult
            {
                Succeeded = false,
                Error = $"Error occurred: {ex.Message}"
            };
        }
    }

    public async Task<BookingResult<IEnumerable<Booking>>> GetAllBookingsAsync()
    {
        var result = await _bookingRepository.GetAll();
        var bookings = result.Result?.Select(x => new Booking
        {
            Id = x.Id,
            EventId = x.EventId,
            PackageId = x.PackageId,
            BookingDate = x.BookingDate,
            TicketQuantity = x.TicketQuantity,
            FirstName = x.BookingGuest?.FirstName ?? string.Empty,
            LastName = x.BookingGuest?.LastName ?? string.Empty,
            Email = x.BookingGuest?.Email ?? string.Empty,
            PhoneNumber = x.BookingGuest?.PhoneNumber ?? string.Empty,
            Street = x.BookingGuest?.GuestAddress?.Street ?? string.Empty,
            PostalCode = x.BookingGuest?.GuestAddress?.PostalCode ?? string.Empty,
            City = x.BookingGuest?.GuestAddress?.City ?? string.Empty,
            Country = x.BookingGuest?.GuestAddress?.Country ?? string.Empty
        });
      

        return new BookingResult<IEnumerable<Booking>>
        {
            Succeeded = result.Succeeded,
            Result = bookings
        };
    }

    public async Task<BookingResult<Booking?>> GetBookingByIdAsync(string id)
    {
        var result = await _bookingRepository.GetAsync(x => x.Id == id);
        if (result.Succeeded && result.Result != null)
        {
            var selectedBooking = new Booking
            {
                Id = result.Result.Id,
                EventId = result.Result.EventId,
                PackageId = result.Result.PackageId,
                BookingDate = result.Result.BookingDate,
                TicketQuantity = result.Result.TicketQuantity,
                FirstName = result.Result.BookingGuest?.FirstName ?? string.Empty,
                LastName = result.Result.BookingGuest?.LastName ?? string.Empty,
                Email = result.Result.BookingGuest?.Email ?? string.Empty,
                PhoneNumber = result.Result.BookingGuest?.PhoneNumber ?? string.Empty,
                Street = result.Result.BookingGuest?.GuestAddress?.Street ?? string.Empty,
                PostalCode = result.Result.BookingGuest?.GuestAddress?.PostalCode ?? string.Empty,
                City = result.Result.BookingGuest?.GuestAddress?.City ?? string.Empty,
                Country = result.Result.BookingGuest?.GuestAddress?.Country ?? string.Empty
            };
            return new BookingResult<Booking?>
            {
                Succeeded = true,
                Result = selectedBooking
            };
        }
        else
        {
            return new BookingResult<Booking?>
            {
                Succeeded = false,
                Error = result.Error
            };
        }

    }
}
