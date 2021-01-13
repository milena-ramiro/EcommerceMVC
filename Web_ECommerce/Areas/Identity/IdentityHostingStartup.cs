using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Web_ECommerce.Areas.Identity.IdentityHostingStartup))]
namespace Web_ECommerce.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
