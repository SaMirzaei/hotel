namespace Hotel.Controllers
{
    using System;
    using System.Net;

    using Hotel.Models;
    using Hotel.Services.Abstracts;

    using Microsoft.AspNetCore.Mvc;

    public class HotelsController : MainController
    {
        private readonly IHotelManagement _hotelManagement;

        public HotelsController(IHotelManagement hotelManagement)
        {
            _hotelManagement = hotelManagement;
        }

        [HttpGet("{hotelID}/{arrivalDate}")]
        [ProducesResponseType(typeof(RootObject), (int)HttpStatusCode.OK)]
        public IActionResult Get(int hotelID, DateTime arrivalDate)
        {
            var result = _hotelManagement.GetHotels(hotelID, arrivalDate);

            return Ok(result);
        }
    }
}
