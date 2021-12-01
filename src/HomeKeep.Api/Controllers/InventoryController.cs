using HomeKeep.Application.Inventories.Commands;
using HomeKeep.Application.Inventories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeKeep.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetInventoriesAsync()
    {
        var inventories = await _mediator.Send(new GetInventoriesQuery());
        return Ok(inventories);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateInventoryAsync(CreateInventoryCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }
}