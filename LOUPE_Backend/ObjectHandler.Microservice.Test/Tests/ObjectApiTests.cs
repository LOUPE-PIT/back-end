
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ObjectHandler.Microservice.Data;
using ObjectHandler.Microservice.Test.Stubs;
using System.Net.Http;
using Xunit;

namespace ObjectHandler.Microservice.Test
{
    public class ObjectApiTests : WebApplicationFactory<Program>
    {
        ObjectDALStub Obstub = new ObjectDALStub();
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IObjectDAL, ObjectDALStub>();
            });

            return base.CreateHost(builder);
        }

        [Fact]
        public async void GetAllObjects_Passed()
        {
            // Arrange
            var webAppFactory = new ObjectApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            Obstub.testValue = true;

            // Act
            var response = await httpClient.GetAsync("/objects/getall");

            // Assert
            response.EnsureSuccessStatusCode();

        }
    }
}