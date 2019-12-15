namespace Hotel.Models
{
    using Newtonsoft.Json;

    public class RateTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shape")]
        public bool Shape { get; set; }
    }
}
