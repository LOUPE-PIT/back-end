using GroupingService.Core.Api.Services;
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

    public GroupingController(IGroupService groupService)
    {
        _groupService = groupService;
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

    [HttpGet("{groupId}")]
    [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ById(Guid groupId)
    {
        var group = await _groupService.ById(groupId);
        
        if (group is null)
        {
            return NotFound();
        }

        return Ok(group);
    }
}