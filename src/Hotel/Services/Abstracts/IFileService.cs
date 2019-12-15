namespace Hotel.Services.Abstracts
{
    public interface IFileService
    {
        string Read(string path);

        void Write(string path, string content);

        bool FileExists(string path);

        string Combine(params string[] paths);
    }
}
