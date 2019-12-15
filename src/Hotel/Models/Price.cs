namespace Hotel.Models
{
    using Newtonsoft.Json;

    public class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("numericFloat")]
        public double NumericFloat { get; set; }

        [JsonProperty("numericInteger")]
        public int NumericInteger { get; set; }
    }
}
