using LogService.Core.Api.Services;
using LogService.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogService.Api;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class LogController : ControllerBase
{
    //Service
    private readonly ILogService _logService;

    public LogController(ILogService logService)
    {
        _logService = logService;
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(Log), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> All()
    {
        return Ok(await _logService.GetAll());
    }

    [HttpGet("byid")]
    [ProducesResponseType(typeof(Log), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ById(Guid id)
    {
        return Ok(await _logService.ById(id));
    }
    [HttpPost("new")]
    [ProducesResponseType(typeof(Log), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> New(Log log)
    {
        return Ok(await _logService.New(log));
    }
}