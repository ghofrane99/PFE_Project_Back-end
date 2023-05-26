using System;
using Microsoft.Extensions.DependencyInjection;
using GMC.Data;
using GMC.Service;
using Microsoft.EntityFrameworkCore;

namespace EmailReportService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure services
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var pickListService = scope.ServiceProvider.GetRequiredService<IPickListService>();
                var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();
                var report = pickListService.GeneratePickListReportAsync().GetAwaiter().GetResult();
                emailService.SendEmail("service.sagemcom@gmail.com", "control.sagemcom@gmail.com", "Sujet", "Le mail marche trés bien.", report);
            }

            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContextPool<DataContext>(options =>
                options.UseSqlServer("server=LAPTOP-3SEDVKNI;Database=GMCDbTest;User ID=ghof;Password=ghof;Trusted_Connection=True;Encrypt=False"));

            services.AddScoped<IPickListRepository, PickListRepository>();
            services.AddScoped<IPickListService, PickListService>();
            services.AddScoped<EmailService>();
        }
    }
}
