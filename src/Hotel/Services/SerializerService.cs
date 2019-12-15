namespace Hotel.Services
{
    using Hotel.Services.Abstracts;

    using Newtonsoft.Json;

    public class SerializerService : ISerializerService
    {
        public string ToJson(object @object)
        {
            return JsonConvert.SerializeObject(@object);
        }

        public T FromJson<T>(string json)
            where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}