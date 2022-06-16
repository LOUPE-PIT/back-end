using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ObjectHandler.Microservice.Data;
using ObjectHandler.Microservice.Test.Stubs;
using System.IO;
using System.Net.Http;
using Xunit;

namespace ObjectHandler.Microservice.Test
{
    // test mostly written to run thought the pipeline. No real value.
    public class ObjectApiTests : WebApplicationFactory<Program>
    {
        ObjectDALStub Obstub = new ObjectDALStub();
        FTPDALStub FTPstub = new FTPDALStub();
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IObjectDAL, ObjectDALStub>();
                services.AddScoped<IFTPObjectDAL, FTPDALStub>();
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

        [Fact]
        public async void UploadObjects_Passed()
        {
            // Arrange
            var webAppFactory = new ObjectApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            Obstub.testValue = true;
            FTPstub.testValue = true;

            // Act
            HttpResponseMessage response;


            using (var file1 = File.OpenRead("../../../Files/image.png"))
            using (var content1 = new StreamContent(file1))
            using (var formdata = new MultipartFormDataContent())
            {
                formdata.Add(content1, "files", "image.png");
                formdata.Add(new StringContent("description"), "description");

                response = await httpClient.PostAsync("object/upload", formdata);
            }

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}