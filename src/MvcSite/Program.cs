using Microsoft.AspNetCore.Hosting;

namespace MvcSite
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .CaptureStartupErrors(true)
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}