namespace Hotel.Services
{
    using Hotel.Services.Abstracts;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IFileService, FileService>()
                .AddTransient<ISerializerService, SerializerService>()
                .AddTransient<IHotelManagement, HotelManagement>();
        }
    }
}
