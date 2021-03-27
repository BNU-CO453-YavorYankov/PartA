using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WebApps.Areas.Identity.IdentityHostingStartup))]
namespace WebApps.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}