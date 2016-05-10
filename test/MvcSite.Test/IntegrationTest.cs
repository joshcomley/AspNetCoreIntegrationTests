using System;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace MvcSite.Test
{
    public class IntegrationTest
    //        where TStartup : class
    {
        [Fact]
        public async void Returns200()
        {
            var builder = new WebHostBuilder()
                                    .UseEnvironment("Development")
                                    .UseContentRoot(GetApplicationPath("../../../../../../src/MvcSite"))
                                    .UseStartup<Startup>();
            var server = new TestServer(builder);
            var client = server.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/Home/Index");

            var result = await client.SendAsync(request);
            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            Assert.True(result.StatusCode == HttpStatusCode.OK);
        }
        private static string GetApplicationPath(string relativePath)
        {
            var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationPath = Path.GetFullPath(Path.Combine(applicationBasePath, relativePath));
            Console.WriteLine("Application path: " + applicationPath);
            return applicationPath;
        }
    }
}
