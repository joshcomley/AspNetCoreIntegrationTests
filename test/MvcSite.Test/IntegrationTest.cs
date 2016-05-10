using System;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace MvcSite.Test
{
    public class IntegrationTest
    {
        [Fact]
        public async void Returns200()
        {
            var builder = new WebHostBuilder()
                                    .UseEnvironment("Development")
                                    //.UseContentRoot(Path.GetFullPath(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "..", "..", "src", "MvcSite")))
                                    .UseContentRoot(@"D:\C\ASPNET5-MVC6-Integration-Tests\src\MvcSite")
                                    //.UseServices(services =>
                                    //{
                                    //    // Change the application environment to the mvc project
                                    //    var env = new TestApplicationEnvironment();
                                    //    env.ApplicationBasePath = ;
                                    //    env.ApplicationName = "MvcSite";

                                    //    services.AddInstance<IApplicationEnvironment>(env);
                                    //})
                                    .UseStartup<Startup>();
            var server = new TestServer(builder);
            var client = server.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/Home/Index");

            var result = await client.SendAsync(request);
            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            Assert.True(result.StatusCode == HttpStatusCode.OK);
        }
    }
}
