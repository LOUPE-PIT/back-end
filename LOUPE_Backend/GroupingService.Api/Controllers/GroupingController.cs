using GroupingService.Core.Api.Services;
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
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> All()
    {
        var groups = await _groupService.GetAll();

        return Ok(groups);
    }
}