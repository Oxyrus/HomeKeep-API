using HomeKeep.Application.Items.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeKeep.Api.Controllers;

[ApiController]
[Route("api/inventory/{inventoryId:guid}/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateItemAsync([FromRoute] Guid inventoryId, [FromBody] CreateItemCommand command)
    {
        if (inventoryId != command.InventoryId)
            return BadRequest();

        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPatch("{itemId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> MarkItemAsPurchasedAsync([FromRoute] Guid inventoryId, [FromRoute] Guid itemId)
    {
        await _mediator.Send(new MarkItemAsPurchasedCommand
        {
            InventoryId = inventoryId,
            ItemId = itemId
        });

        return StatusCode(StatusCodes.Status204NoContent);
    }
}