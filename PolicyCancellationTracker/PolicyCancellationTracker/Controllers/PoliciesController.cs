using Microsoft.AspNetCore.Mvc;
using PolicyCancellationTracker.Models;
using PolicyCancellationTracker.Services;

namespace PolicyCancellationTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class PoliciesController : ControllerBase
{
    private readonly CancellationService _cancellationService;
    
    public PoliciesController(CancellationService cancellationService)
    {
        _cancellationService = cancellationService;
    }

    [HttpGet]
    public IActionResult GetPolicies()
    {
        var records = _cancellationService.GetRecords();
        
        return Ok(records);
    }
}