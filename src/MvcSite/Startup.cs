using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MvcSite
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .CaptureStartupErrors(true)
                .UseStartup<Startup>();
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();
        }
		
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();

			app.UseMvc(routes =>
				routes.MapRoute("default", "{controller}/{action}", new { controller = "home", action = "index" }));
        }
    }
}
