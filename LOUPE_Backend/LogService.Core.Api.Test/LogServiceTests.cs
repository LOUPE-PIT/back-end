using System.Collections.ObjectModel;
using LogService.Core.Api.Services;
using LogService.DataAccessLayer.Repositories;
using LogService.DataAccessLayer.Models;
using FluentAssertions;
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
                Id = Guid.Parse("13baf352-cdb8-4c69-ba84-124d4b773fb"),
                UserId = Guid.Parse("596d9da2-905e-48e4-aab5-41b29c89786f"),
                GroupId = Guid.Parse("596d9da2-905e-48e4-aab5-41b29c89786c"),
                Text = "Ilias has added a model",
                Created = new DateTimeOffset(DateTime.Now)
            },
        };

        _logRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(expectedLogs);
        
        // Act
        var result = await _logService.GetAll();
        
        // Assert
        result.Should().BeEquivalentTo(expectedLogs);
    }
}