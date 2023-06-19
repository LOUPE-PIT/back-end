using System.Collections.ObjectModel;
using LogService.Core.Api.Services;
using LogService.DataAccessLayer.Repositories;
using LogService.DataAccessLayer.Models;
using FluentAssertions;
using LogService.Core.Api.Contracts;
using Moq;

namespace LogService.Core.Api.Test;

[TestFixture]
public class LogServiceTests
{
    //Service
    private ILogService _logService;
    private Mock<ILogRepository> _logRepositoryMock;

    [SetUp]
    public void Setup()
    {
        // Initialize the LogService with a mocked repository
        _logRepositoryMock = new Mock<ILogRepository>();
        _logService = new Services.LogService(_logRepositoryMock.Object);
    }

    [Test]
    public async Task GetAll_ReturnsCollectionOfLogs()
    {
        // Arrange
        var expectedLogs = new Collection<Log>
        {
            new Log
            {
                Id = Guid.Parse("6af419dc-fe99-4b0f-8f64-363eb13294b4"),
                UserId = Guid.Parse("db5ddb4e-9e6d-46db-bee5-ac60af539130"),
                GroupId = Guid.Parse("c7977d28-a339-402a-afc2-1f01b89c3d04"),
                Text = "Ilias has added a log",
                Created = new DateTimeOffset(DateTime.Now)
            },
        };

        _logRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(expectedLogs);

        // Act
        var result = await _logService.GetAll();

        // Assert
        result.Should().BeEquivalentTo(expectedLogs);
    }

    [Test]
    public async Task GetById_ReturnLog()
    {
        // Arrange
        var expectedLog = new Log
        {
            Id = Guid.Parse("6af419dc-fe99-4b0f-8f64-363eb13294b4"),
            UserId = Guid.Parse("db5ddb4e-9e6d-46db-bee5-ac60af539130"),
            GroupId = Guid.Parse("c7977d28-a339-402a-afc2-1f01b89c3d04"),
            Text = "Ilias has added a log",
            Created = new DateTimeOffset(DateTime.Now)
        };

        _logRepositoryMock.Setup(x => x.ByGroupId(expectedLog.Id)).ReturnsAsync(expectedLog);

        // Act
        var result = await _logService.ByGroupId(expectedLog.Id);

        // Assert
        result.Should().BeEquivalentTo(expectedLog);
    }

    [Test]
    public async Task New_ReturnActionResult()
    {
        // Arrange
        var expectedResponse = new LogResponse()
        {
            Result = ActionResult.Succesvol
        };
        var newLog = new Log
        {
            Id = Guid.Parse("6af419dc-fe99-4b0f-8f64-363eb13294b4"),
            UserId = Guid.Parse("db5ddb4e-9e6d-46db-bee5-ac60af539130"),
            GroupId = Guid.Parse("c7977d28-a339-402a-afc2-1f01b89c3d04"),
            Text = "Ilias has added a log",
            Created = new DateTimeOffset(DateTime.Now)
        };

        _logRepositoryMock.Setup(x => x.New(newLog));

        // Act
        var result = await _logService.New(newLog);

        // Assert
        result.Should().BeEquivalentTo(expectedResponse);
    }

    [Test]
    public async Task Update_ReturnActionResult()
    {
        // Arrange
        var expectedResponse = new LogResponse()
        {
            Result = ActionResult.Succesvol
        };
        var newLog = new Log
        {
            Id = Guid.Parse("6af419dc-fe99-4b0f-8f64-363eb13294b4"),
            UserId = Guid.Parse("db5ddb4e-9e6d-46db-bee5-ac60af539130"),
            GroupId = Guid.Parse("c7977d28-a339-402a-afc2-1f01b89c3d04"),
            Text = "Ilias has added a log",
            Created = new DateTimeOffset(DateTime.Now)
        };
        var existingLog = new Log
        {
            Id = Guid.Parse("6af419dc-fe99-4b0f-8f64-363eb13294b4"),
            UserId = Guid.Parse("db5ddb4e-9e6d-46db-bee5-ac60af539130"),
            GroupId = Guid.Parse("c7977d28-a339-402a-afc2-1f01b89c3d04"),
            Text = "Ilias has updated a log",
            Created = new DateTimeOffset(DateTime.Now)
        };
        await _logService.New(newLog);
        _logRepositoryMock.Setup(x => x.Update(existingLog));
        
        // Act
        var result = await _logService.Update(existingLog);

        // Assert
        result.Should().BeEquivalentTo(expectedResponse);
    }

    [Test]
    public async Task Delete_ReturnActionResult()
    {
        // Arrange
        var expectedResponse = new LogResponse()
        {
            Result = ActionResult.Succesvol
        };
        var newLog = new Log
        {
            Id = Guid.Parse("6af419dc-fe99-4b0f-8f64-363eb13294b4"),
            UserId = Guid.Parse("db5ddb4e-9e6d-46db-bee5-ac60af539130"),
            GroupId = Guid.Parse("c7977d28-a339-402a-afc2-1f01b89c3d04"),
            Text = "Ilias has added a log",
            Created = new DateTimeOffset(DateTime.Now)
        };
        var existingLog = new Log
        {
            Id = Guid.Parse("6af419dc-fe99-4b0f-8f64-363eb13294b4"),
            UserId = Guid.Parse("db5ddb4e-9e6d-46db-bee5-ac60af539130"),
            GroupId = Guid.Parse("c7977d28-a339-402a-afc2-1f01b89c3d04"),
            Text = "Ilias has updated a log",
            Created = new DateTimeOffset(DateTime.Now)
        };
        await _logService.New(newLog);
        _logRepositoryMock.Setup(x => x.Delete(existingLog));
        
        // Act
        var result = await _logService.Delete(existingLog);

        // Assert
        result.Should().BeEquivalentTo(expectedResponse);
    }
}