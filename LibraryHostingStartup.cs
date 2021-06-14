using DotNetCoreDiDemo.Library;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using LibraryHostingStartup = DotNetCoreDiDemo.LibraryHostingStartup;

[assembly: HostingStartup(typeof(LibraryHostingStartup))]
namespace DotNetCoreDiDemo
{
    public class LibraryHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddScoped<IOrderService, OrderService>();
            });
        }
    }
}
