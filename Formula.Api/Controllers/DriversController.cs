using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries.Driver;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriversController : BaseController
{
    private readonly IMediator _mediator;

    public DriversController(IMediator mediator) : base(mediator)   
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetDrivers()
    {
        // Speficying the query
        var query = new GetAllDriversQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{driverId:guid}")]
    public async Task<IActionResult> GetDriverById(Guid driverId)
    {
        // Speficying the query
        var query = new GetDriverQuery(driverId);
        var result = await _mediator.Send(query);
        if(result == null)
        {
            return NotFound(); 
        }
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new CreateDriverInfoRequest(driver);   
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetDriverById), new { driverId = result.DriverId }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverRequest updateDriver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new UpdateDriverInfoRequest(updateDriver);
        var result = await _mediator.Send(command);
        return result ? NoContent() : BadRequest();

    }

    [HttpDelete("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid id)
    {
        var command = new DeleteDriverInfoRequest(id);
        var result = await _mediator.Send(command);
        return result ? NoContent() : BadRequest();
    }
}
