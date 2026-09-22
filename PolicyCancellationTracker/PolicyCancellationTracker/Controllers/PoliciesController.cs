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
    
    [HttpPost]
    public async Task<IActionResult> CreatePolicy(CancellationRecord record)
    {
        _context.CancellationRecords.Add(record);
        await _context.SaveChangesAsync();
    
        return CreatedAtAction(
            nameof(GetPolicy),
            new { id = record.Id },
            record);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePolicy(int id)
    {
        CancellationRecord? record =
            await _context.CancellationRecords.FindAsync(id);
        
        if (record == null) 
        {
            return NotFound();
        }
        
        _context.CancellationRecords.Remove(record);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

[HttpPut("{id}")]
public async Task<IActionResult> UpdatePolicy(
    int id, CancellationRecord updatedRecord)
{
    CancellationRecord? record =
        await _context.CancellationRecords.FindAsync(id);

    if (record == null)
    {
        return NotFound();
    }

    record.PolicyNumber = updatedRecord.PolicyNumber;
    record.InsuredName = updatedRecord.InsuredName;
    record.PolicyType = updatedRecord.PolicyType;
    record.EffectiveDate = updatedRecord.EffectiveDate;
    record.ExpirationDate = updatedRecord.ExpirationDate;
    record.CancellationDate = updatedRecord.CancellationDate;
    record.NoticeDate = updatedRecord.NoticeDate;
    record.CancellationReason = updatedRecord.CancellationReason;
    record.AmountDue = updatedRecord.AmountDue;
    record.Status = updatedRecord.Status;
    record.Notes = updatedRecord.Notes;

    await _context.SaveChangesAsync();

    return NoContent();
}
}