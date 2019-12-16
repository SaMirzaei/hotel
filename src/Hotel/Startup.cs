namespace Hotel
{
    using System;

    using Hotel.Services;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    using Swashbuckle.AspNetCore.SwaggerGen;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostEnvironment env)
        {
            var environmentName = env.EnvironmentName;

            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<AppOptions>(_configuration.GetSection("app"))
                .AddMvcCore(
                    options =>
                    {
                        options.RespectBrowserAcceptHeader = true;
                        options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                        options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                        options.EnableEndpointRouting = false;
                    })
                .AddFormatterMappings()
                .AddXmlSerializerFormatters()
                .AddApiExplorer()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services
                .AddSingleton<Func<DateTime>>(() => DateTime.UtcNow)
                .AddServices()
                .AddSwaggerGen(ConfigureSwaggerDocGen)
                .AddLogging(
                    logginBuilder =>
                    {
                        logginBuilder.AddConfiguration(_configuration.GetSection("Logging"))
                            .AddConsole();
                    })
                .AddResponseCompression();

            services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    options.RoutePrefix = string.Empty;
                });

            app.UseResponseCompression()
                .UseMvc();
        }

        private void ConfigureSwaggerDocGen(SwaggerGenOptions options)
        {
            options.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "HQ Plush Hotel API",
                    Version = "v1",
                    Description = "HQ Plusy Company",
                    TermsOfService = new Uri("http://www.hqplus.de/licenses"),
                    Contact = new OpenApiContact
                    {
                        Name = "HQ Plus",
                        Email = "hqplus.de@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "HQ Plus",
                        Url = new Uri("http://www.hqplus.de")
                    }
                });
        }
    }
}