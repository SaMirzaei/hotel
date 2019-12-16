namespace Hotel.Controllers
{
    using System;
    using System.Net;

    using Hotel.Models;
    using Hotel.Services.Abstracts;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class HotelsController : MainController
    {
        private readonly IHotelManagement _hotelManagement;

        public HotelsController(IHotelManagement hotelManagement)
        {
            _hotelManagement = hotelManagement;
        }

        [ProducesResponseType(typeof(RootObject), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{hotelID}/{arrivalDate}")]
        public IActionResult Get(int hotelID, DateTime arrivalDate)
        {
            var result = _hotelManagement.GetHotels(hotelID, arrivalDate);

            return Ok(result);
        }
    }
}
