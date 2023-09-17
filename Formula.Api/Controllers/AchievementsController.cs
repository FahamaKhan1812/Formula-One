using FormulaOne.Api.Commands.Achievement;
using FormulaOne.Api.Queries.Achievement;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AchievementsController : BaseController
{
    private readonly IMediator _mediator;
    public AchievementsController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        // Speficying the query
        var query = new GetDriverAchievementQuery(driverId);
        var result = await _mediator.Send(query);
        if(result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
    {
        if(!ModelState.IsValid)
            return BadRequest();

        var command = new CreateDriverAchievementInfoRequest(achievement);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.Id }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest updateDriver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new UpdateDriverAchievementInfoRequest(updateDriver);
        var result = await _mediator.Send(command);
        return result ? NoContent() : BadRequest();
    }

}
