using PolicyCancellationTracker.Models;

namespace PolicyCancellationTracker.Services;

public class CancellationService
{
    private readonly List<CancellationRecord> _records =
    [
        new CancellationRecord
        {
            Id = 1,
            PolicyNumber = "ABP123456789",
            InsuredName = "Jose Vargas",
            PolicyType = "Commercial Auto",
            EffectiveDate = new DateTime(2026, 04, 15),
            AmountDue = 325.50m,
            Status = "Notice Sent",
            CancellationDate = new DateTime(2026, 06, 15),
            CancellationReason = "Nonpayment of premium",
            ExpirationDate = new DateTime(2027, 04, 15),
            Notes = "Cancellation notice mailed to the insured.",
            NoticeDate = new DateTime(2026, 06, 01),
        },
        new CancellationRecord
        {
            Id = 2,
            PolicyNumber = "ABP123456789",
            InsuredName = "Cooper Graves",
            PolicyType = "Personal Auto",
            EffectiveDate = new DateTime(2026, 05, 15),
            AmountDue = 525.50m,
            Status = "Pending Review",
            CancellationDate = new DateTime(2027, 07, 15),
            CancellationReason = "Requested by insured",
            ExpirationDate = new DateTime(2027, 05, 15),
            Notes = "Written cancellation request received.",
            NoticeDate = new DateTime(2027, 07, 01),
        }
    ];
    
    public List<CancellationRecord> GetRecords()
    {
        return _records;
    }

    public CancellationRecord? GetRecordById(int id)
    {
        return _records.FirstOrDefault(record => record.Id == id);
    }

    public void UpdateRecord(CancellationRecord updatedRecord)
    {
        CancellationRecord? existingRecord = _records.FirstOrDefault(record => record.Id == updatedRecord.Id);

        if (existingRecord is null)
        {
            return;
        }
        
        existingRecord.Status = updatedRecord.Status;
        existingRecord.Notes = updatedRecord.Notes;
    }
}