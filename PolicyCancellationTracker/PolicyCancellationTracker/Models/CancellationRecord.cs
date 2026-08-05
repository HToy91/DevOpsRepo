using System.ComponentModel.DataAnnotations;

namespace PolicyCancellationTracker.Models;

public class CancellationRecord
{
    public int Id { get; set; }
    [Required]
    public string PolicyNumber { get; set; } = string.Empty;
    [Required]
    public string InsuredName { get; set; } = string.Empty;
    public string PolicyType { get; set; } = string.Empty;
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime CancellationDate { get; set; }
    public DateTime? NoticeDate { get; set; }
    public string CancellationReason { get; set; } = string.Empty;
    public decimal AmountDue { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}