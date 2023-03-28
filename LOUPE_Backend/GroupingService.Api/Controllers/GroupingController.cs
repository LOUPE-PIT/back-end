using GroupingService.Core.Api.Services;
using GroupingService.Core.Api.Services.GroupService;
using GroupingService.Core.Api.Services.RoomCodeService;
using GroupingService.Core.Api.ViewModels;
using GroupingService.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GroupingService.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[SwaggerTag("Acties rondom groepen")]
public class GroupingController : ControllerBase
{
    //Service
    private readonly IGroupService _groupService;
    private readonly IRoomCodeService _roomCodeService;

    public GroupingController(IGroupService groupService, IRoomCodeService roomCodeService)
    {
        _groupService = groupService;
        _roomCodeService = roomCodeService;
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> All()
    {
        var groups = await _groupService.GetAll();
        return Ok(groups);
    }

    [HttpGet("{roomCode}")]
    [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ByRoomCode(string roomCode)
    {
        var group = await _groupService.ByRoomCode(roomCode);
        if (group is null)
        {
            return NotFound();
        }
        return Ok(group);
    }

    [HttpPost("new")]
    [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> New([FromBody] GroupRequestBody group)
    {
        var roomCode = "EFG";
            // await _roomCodeService.GenerateRoomCode();
         _groupService.New(roomCode, group);
         
         return Ok();
    }
}