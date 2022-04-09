using AsyncArch.Core.Ports;
using Microsoft.AspNetCore.Mvc;

namespace AsyncArch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    [HttpGet("{operationId:guid}")]
    public async Task<IActionResult> Get(
        [FromRoute] Guid operationId,
        [FromServices] ICachePort cache
    )
    {
        var content = await cache.Read(operationId);

        if (content == null)
            return NotFound($"Operation with id {operationId} not founded!");

        await cache.Remove(operationId);
        return Ok(content);
    }
}