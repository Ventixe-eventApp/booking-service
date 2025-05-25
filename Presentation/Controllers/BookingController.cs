using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingRequest request)
    {
        try
        {
           var result = await _bookingService.CreateAsync(request);
            if (!result.Succeeded)
            {
                return StatusCode(result.StatusCode, new { Error = result.Error });
            }
            return Ok(new { Message = "Booking created successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var events = await _bookingService.GetAllBookingsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(string id)
    {
        var selectedEvent = await _bookingService.Ge(id);
        if (selectedEvent == null)
        {
            return NotFound(new { message = "Event not found" });
        }
        return Ok(selectedEvent);
    }
}

