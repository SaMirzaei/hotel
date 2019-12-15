namespace Hotel.Models
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class HotelRate
    {
        [JsonProperty("adults")]
        public int Adults { get; set; }

        [JsonProperty("los")]
        public int Los { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("rateDescription")]
        public string RateDescription { get; set; }

        [JsonProperty("rateID")]
        public string RateID { get; set; }

        [JsonProperty("rateName")]
        public string RateName { get; set; }

        [JsonProperty("rateTags")]
        public List<RateTag> RateTags { get; set; }

        [JsonProperty("targetDay")]
        public DateTime TargetDay { get; set; }
    }
}
