using Microsoft.AspNetCore.Mvc;
using Test2A.Services;

namespace Test2A.Controllers;

[ApiController]
[Route("api/racers")]
public class RacersController : ControllerBase
{
    private readonly DbService _service;
    public RacersController(DbService service) => _service = service;

    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetRacerParticipations(int id)
    {
        var result = await _service.GetRacerParticipation(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}