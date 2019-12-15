namespace Hotel.Services.Abstracts
{
    using System;

    using Hotel.Models;

    public interface IHotelManagement
    {
        RootObject GetHotels(int hotelID, DateTime arrivalDate);
    }
}
