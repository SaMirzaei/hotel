namespace Hotel.Services.Abstracts
{
    public interface ISerializerService
    {
        string ToJson(object @object);

        T FromJson<T>(string json)
            where T : class;
    }
}
