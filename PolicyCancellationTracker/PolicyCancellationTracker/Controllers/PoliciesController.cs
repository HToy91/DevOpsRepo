using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolicyCancellationTracker.Data;
using PolicyCancellationTracker.Models;

namespace PolicyCancellationTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class PoliciesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PoliciesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPolicies()
    {
        List<CancellationRecord> records =
            await _context.CancellationRecords.ToListAsync();

        return Ok(records);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPolicy(int id)
    {
        CancellationRecord? record =
            await _context.CancellationRecords.FindAsync(id);

        if (record == null)
        {
            return NotFound();
        }

        return Ok(record);
    }
}