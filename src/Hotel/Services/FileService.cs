namespace Hotel.Services
{
    using System.IO;

    using Hotel.Services.Abstracts;

    using static System.IO.File;

    public class FileService : IFileService
    {
        public string Read(string path)
        {
            return ReadAllText(path);
        }

        public void Write(string path, string content)
        {
            WriteAllText(path, content);
        }

        public bool FileExists(string path)
        {
            return Exists(path);
        }

        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }
    }
}
