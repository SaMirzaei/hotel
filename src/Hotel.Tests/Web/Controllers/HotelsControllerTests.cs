namespace Hotel.Tests.Web.Controllers
{
    using System;

    using FluentAssertions;

    using Hotel.Controllers;
    using Hotel.Models;
    using Hotel.Services.Abstracts;

    using Microsoft.AspNetCore.Mvc;

    using NSubstitute;

    using NUnit.Framework;

    public class HotelsControllerTests
    {
        private HotelsController _hotelsController;

        private IHotelManagement _hotelManagementService;

        [SetUp]
        public void Setup()
        {
            _hotelManagementService = Substitute.For<IHotelManagement>();

            _hotelsController = new HotelsController(_hotelManagementService);
        }

        [Test]
        public void WhenFoundHotelThenOkResultReturened()
        {
            int hotelID = 1;
            var arriveDate = DateTime.Now;

            _hotelManagementService.GetHotels(hotelID, arriveDate)
                .Returns(info => new RootObject
                {
                    Hotel = new Hotel
                    {
                        HotelID = hotelID,
                    }
                });


            _hotelsController
                .Get(hotelID, arriveDate)
                .Should()
                .BeOfType<OkObjectResult>();
        }

        [Test]
        public void WhenGetHotelIDOneThenOkResultContainRootObjectWithHotelIDOneReturened()
        {
            int hotelID = 1;
            var arriveDate = DateTime.Now;

            _hotelManagementService.GetHotels(hotelID, arriveDate)
                .Returns(info => new RootObject
                                     {
                                         Hotel = new Hotel
                                                     {
                                                         HotelID = hotelID,
                                                     }
                                     });

            var rootObject = ((OkObjectResult)_hotelsController.Get(hotelID, arriveDate)).Value as RootObject;

            rootObject?.Hotel.HotelID
                .Should()
                .Be(hotelID);
        }
    }
}
