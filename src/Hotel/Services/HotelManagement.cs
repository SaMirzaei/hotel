namespace Hotel.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Hotel.Models;
    using Hotel.Services.Abstracts;

    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    public class HotelManagement : IHotelManagement
    {
        private readonly IFileService _fileService;

        private readonly ISerializerService _serializerService;

        private readonly IHostEnvironment _environment;

        private readonly AppOptions _options;

        public HotelManagement(
            IFileService fileService,
            ISerializerService serializerService,
            IHostEnvironment environment,
            IOptions<AppOptions> options)
        {
            _fileService = fileService;
            _serializerService = serializerService;
            _environment = environment;
            _options = options.Value;
        }

        public RootObject GetHotels(int hotelID, DateTime arrivalDate)
        {
            var file = _fileService.Combine(_environment.ContentRootPath, _options.Filename);

            if (!_fileService.FileExists(file))
            {
                throw new FileNotFoundException($"File not found {file}");
            }

            var json = _fileService.Read(file);
            var hotels = _serializerService.FromJson<IEnumerable<RootObject>>(json);

            var result = hotels
                .Where(t => t.Hotel.HotelID == hotelID)
                .Select(t => new RootObject
                {
                    Hotel = t.Hotel,
                    HotelRates = t.HotelRates.Where(q => q.TargetDay >= arrivalDate).ToList()
                });

            return result.FirstOrDefault();
        }
    }
}
