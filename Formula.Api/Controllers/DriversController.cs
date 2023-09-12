using AutoMapper;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriversController : BaseController
{
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet("")]
    public async Task<IActionResult> GetDrivers()
    {
        var drivers = await _unitOfWork.Drivers.All();
        var result = _mapper.Map<IEnumerable<DriverResponse>>(drivers);

        return Ok(result);
    }

    [HttpGet("{driverId:guid}")]
    public async Task<IActionResult> GetDriverById(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);
        if (driver == null)
        {
            return NotFound("No Driver found");
        }
        var result = _mapper.Map<DriverResponse>(driver);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Driver>(driver);
        await _unitOfWork.Drivers.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverById), new { driverId = result.Id }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverRequest updateDriver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Driver>(updateDriver);
        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpDelete("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid id)
    {
        var driver = await _unitOfWork.Drivers.GetById(id);
        if (driver == null)
        {
            return NotFound("No Driver found");
        }

        await _unitOfWork.Drivers.Delete(id);
        await _unitOfWork.CompleteAsync();

        return NoContent();

    }
}
