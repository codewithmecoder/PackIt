using Microsoft.AspNetCore.Mvc;
using PackIT.Abstraction.Commands;
using PackIT.Abstraction.Queries;
using PackIT.Application.Commands;
using PackIT.Application.DTO;
using PackIT.Application.Queries;

namespace PackIT.Api.Controllers;

public class PackingListsController : BaseController
{
    private readonly IQueryDispatcher _query;
    private readonly ICommandDispatcher _command;

    public PackingListsController(
        IQueryDispatcher query,
        ICommandDispatcher command)
    {
        _query = query;
        _command = command;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingListQuery query)
    {
        var result = await _query.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromQuery] SearchPackingLists query)
    {
        var result = await _query.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePackingListWithItemCommand cmd)
    {
        await _command.DispatchAsync(cmd);
        return CreatedAtAction(nameof(Get), new { cmd.Id }, null);
    }

    [HttpPut("{packingListId}/items")]
    public async Task<IActionResult> Put([FromBody] AddPackingItem cmd)
    {
        await _command.DispatchAsync(cmd);
        return Ok();
    }

    [HttpPut("{packingListId:guid}/items/{name}/pack")]
    public async Task<IActionResult> Put([FromBody] PackItem cmd)
    {
        await _command.DispatchAsync(cmd);
        return Ok();
    }

    [HttpDelete("{packingListId:guid}/items/{name}")]
    public async Task<IActionResult> Delete([FromBody] RemovePackingItem cmd)
    {
        await _command.DispatchAsync(cmd);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] RemovePackingList cmd)
    {
        await _command.DispatchAsync(cmd);
        return Ok();
    }
}
