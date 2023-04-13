using System.Collections.ObjectModel;
using FluentAssertions;
using GroupingService.Core.Api.Services;
using GroupingService.Core.Api.Services.GroupService;
using GroupingService.Core.Api.Services.GroupService.Implementation;
using GroupingService.DataAccessLayer.Repositories;
using GroupingService.DataAccessLayer.Models;
using Moq;

namespace GroupingService.Core.Api.Test;

[TestFixture]
public class GroupServiceTests
{
    //Service
    private IGroupService _groupService;
    private Mock<IGroupRepository> _groupingRepositoryMock;

    [SetUp]
    public void SetUp()
    {
        // Initialize the GroupService with a mocked repository
        _groupingRepositoryMock = new Mock<IGroupRepository>();
        _groupService = new GroupService(_groupingRepositoryMock.Object);
    }
    
    [Test]
    public async Task GetAll_ReturnsCollectionOfGroups()
    {
        // Arrange
        var expectedGroups = new Collection<Group>
        {
            new Group {
                RoomCode = "ABCDEFG",
                UserId = Guid.Parse("596d9da2-905e-48e4-aab5-41b29c89786f"), 
            },
        };

        _groupingRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(expectedGroups);

        // Act
        var result = await _groupService.GetAll();

        // Assert
        result.Should().BeEquivalentTo(expectedGroups);
    }
}