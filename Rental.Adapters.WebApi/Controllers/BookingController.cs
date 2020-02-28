using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental.Application.UseCases;
using Rental.Domain;
using Rental.Domain.Exceptions;
using RentalApp.Adapters.WebApi.Models;

namespace RentalApp.Adapters.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly BookCarUseCase _bookCarUseCase;

        public BookingController(ILogger<BookingController> logger, BookCarUseCase bookCarUseCase)
        {
            _logger = logger;
            _bookCarUseCase = bookCarUseCase;
        }

        [HttpPost]
        public IActionResult BookCar([FromBody] BookCarRequest bookCarRequest)
        {
            try
            {
                _bookCarUseCase.Book(bookCarRequest.CarId, bookCarRequest.StartDate, bookCarRequest.EndDate);
                _logger.Log(LogLevel.Debug, $"Booking created for {bookCarRequest.CarId}");
                return Accepted();
            }
            catch (CarIsAlreadyBookedException e)
            {
                return BadRequest(e.Message);
            }
            catch (CarDoesNotExistsException e)
            {
                return NotFound(bookCarRequest.CarId);
            }
        }
    }
}
