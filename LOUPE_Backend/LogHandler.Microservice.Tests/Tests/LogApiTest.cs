using LogHandler.Microservice.Data;
using LogHandler.Microservice.Model;
using LogHandler.Microservice.Tests.Stubs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Text;
using Xunit;

namespace LogHandler.Microservice.Tests.Tests
{
    internal class LogApiTest : WebApplicationFactory<LogProgram>
    {
        LogDALStub stub = new LogDALStub();
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<ILogDAL, LogDALStub>();
            });

            return base.CreateHost(builder);
        }

        [Fact]
        public async void GetLogs_Passed()
        {
            //Arrange
            var webAppFactory = new LogApiTest();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            //Act
            var response = await httpClient.GetAsync("/logs/all");

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void InsertLog_Passed()
        {
            //Arrange
            LogModel logModel = new LogModel();
            logModel.log = "test log.";
            logModel.userId = "11";
            logModel.created = DateTime.Now;
            var webAppFactory = new LogApiTest();
            HttpClient httpsClient = webAppFactory.CreateClient();
            stub.testValue = true;

            string json = "{ }";

            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await httpsClient.PostAsync("log/insert", httpContent);

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void GetLogByLogId_Passed()
        {
            LogModel logModel = new LogModel();
            logModel.logId = "1";
            var webAppFactory = new LogApiTest(); ;
            HttpClient httpsClient = webAppFactory.CreateClient();
            stub.testValue = true;

            var response = await httpsClient.GetAsync($"/log/{logModel.logId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void GetLogByUserId_Passed()
        {
            LogModel logModel = new LogModel();
            logModel.userId = "11";
            var webAppFactory = new LogApiTest();
            HttpClient httpsClient = webAppFactory.CreateClient();
            stub.testValue = true;

            var response = await httpsClient.GetAsync($"/log/user/{logModel.userId}");

            response.EnsureSuccessStatusCode();
        }
    }
}
