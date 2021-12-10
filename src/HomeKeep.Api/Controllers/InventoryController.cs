using HomeKeep.Application.Inventories.Commands;
using HomeKeep.Application.Inventories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeKeep.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
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

    [HttpGet("{inventoryId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInventoryByIdAsync([FromRoute] Guid inventoryId)
    {
        return Ok(await _mediator.Send(new GetInventoryByIdQuery(inventoryId)));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateInventoryAsync(CreateInventoryCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }
}