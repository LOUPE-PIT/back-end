using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using Authentication.Microservice.Data;
using Authentication.Microservice.Model;
using AuthenticationService.Microservice.Test.Stubs;
using Xunit;
using System;

namespace AuthenticationService.Microservice.Test
{

    public class AuthenticationApiTests : WebApplicationFactory<Program>
    {
        AuthenticationDALStub stub = new AuthenticationDALStub();
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAuthenticationDAL, AuthenticationDALStub>();
            });

            return base.CreateHost(builder);
        }

        [Fact]
        public async void GetUsers_Passed()
        {
            // Arrange
            var webAppFactory = new AuthenticationApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            // Act
            var response = await httpClient.GetAsync("/user/all");

            // Assert
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async void AddCertainUser_Passed()
        {
            // Arrange
            UserModel userModel = new UserModel();
            userModel.name = "mark";
            userModel.userId = new Guid();
            var webAppFactory = new AuthenticationApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            string json = "{ }";

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await httpClient.PostAsync("/user/add", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}