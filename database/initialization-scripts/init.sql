IF DB_ID('PolicyCancellationTracker') IS NULL
BEGIN
    CREATE DATABASE PolicyCancellationTracker;
END
GO

USE PolicyCancellationTracker;
GO

IF OBJECT_ID('dbo.CancellationRecords', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.CancellationRecords
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        PolicyNumber NVARCHAR(50) NOT NULL,
        InsuredName NVARCHAR(100) NOT NULL,
        PolicyType NVARCHAR(50) NOT NULL,
        EffectiveDate DATETIME2 NOT NULL,
        ExpirationDate DATETIME2 NOT NULL,
        CancellationDate DATETIME2 NOT NULL,
        NoticeDate DATETIME2 NOT NULL,
        CancellationReason NVARCHAR(200) NOT NULL,
        AmountDue DECIMAL(18,2) NOT NULL,
        Status NVARCHAR(50) NOT NULL,
        Notes NVARCHAR(500) NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.CancellationRecords)
BEGIN
    INSERT INTO dbo.CancellationRecords
    (
        PolicyNumber,
        InsuredName,
        PolicyType,
        EffectiveDate,
        ExpirationDate,
        CancellationDate,
        NoticeDate,
        CancellationReason,
        AmountDue,
        Status,
        Notes
    )
    VALUES
    (
        'ABP123456789',
        'Jose Vargas',
        'Commercial Auto',
        '2026-04-15',
        '2027-04-15',
        '2026-06-15',
        '2026-06-01',
        'Nonpayment of premium',
        325.50,
        'Notice Sent',
        'Cancellation notice mailed to the insured.'
    ),
    (
        'ABP987654321',
        'Cooper Graves',
        'Personal Auto',
        '2026-05-15',
        '2027-05-15',
        '2027-07-15',
        '2027-07-01',
        'Requested by insured',
        525.50,
        'Pending Review',
        'Written cancellation request received.'
    ),
    (
        'ABP456789123',
        'Michael Thompson',
        'Homeowners',
        '2026-01-10',
        '2027-01-10',
        '2026-09-10',
        '2026-08-25',
        'Nonpayment of premium',
        875.25,
        'Notice Sent',
        'Payment was not received by the due date.'
    ),
    (
        'ABP741852963',
        'Sarah Martinez',
        'Personal Auto',
        '2026-03-01',
        '2027-03-01',
        '2026-10-01',
        '2026-09-15',
        'Requested by insured',
        215.00,
        'Pending Review',
        'Insured requested cancellation by phone.'
    ),
    (
        'ABP159357486',
        'David Wilson',
        'Commercial Auto',
        '2026-02-20',
        '2027-02-20',
        '2026-08-20',
        '2026-08-05',
        'Nonpayment of premium',
        1240.75,
        'Cancelled',
        'Policy cancelled after required notice period.'
    ),
    (
        'ABP258369147',
        'Emily Johnson',
        'Homeowners',
        '2026-06-01',
        '2027-06-01',
        '2026-11-01',
        '2026-10-15',
        'Property sold',
        450.00,
        'Pending Review',
        'Insured reported that the property was sold.'
    ),
    (
        'ABP369258147',
        'Robert Anderson',
        'Personal Auto',
        '2026-07-12',
        '2027-07-12',
        '2026-12-12',
        '2026-11-28',
        'Nonpayment of premium',
        185.75,
        'Notice Sent',
        'Cancellation notice generated for unpaid premium.'
    ),
    (
        'ABP852741963',
        'Jessica Brown',
        'Commercial Auto',
        '2026-04-05',
        '2027-04-05',
        '2026-09-05',
        '2026-08-20',
        'Business closed',
        1575.00,
        'Cancelled',
        'Insured advised that the business has closed.'
    ),
    (
        'ABP951753852',
        'Daniel Garcia',
        'Homeowners',
        '2026-05-25',
        '2027-05-25',
        '2026-10-25',
        '2026-10-10',
        'Requested by insured',
        610.25,
        'Pending Review',
        'Written cancellation request received from insured.'
    ),
    (
        'ABP753159456',
        'Amanda Davis',
        'Personal Auto',
        '2026-08-01',
        '2027-08-01',
        '2027-01-01',
        '2026-12-15',
        'Nonpayment of premium',
        295.50,
        'Notice Sent',
        'Premium remains unpaid after billing reminder.'
    );
END
GO
