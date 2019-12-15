namespace Hotel.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class RootObject
    {
        [JsonProperty("hotel")]
        public Hotel Hotel { get; set; }

        [JsonProperty("hotelRates")]
        public List<HotelRate> HotelRates { get; set; }
    }
}
