namespace Hotel.Models
{
    using Newtonsoft.Json;

    public class Hotel
    {
        [JsonProperty("classification")]
        public int Classification { get; set; }

        [JsonProperty("hotelID")]
        public int HotelID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("reviewscore")]
        public double ReviewScore { get; set; }
    }
}
