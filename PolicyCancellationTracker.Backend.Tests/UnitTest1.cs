using Microsoft.EntityFrameworkCore;
using PolicyCancellationTracker.Controllers;
using PolicyCancellationTracker.Data;
using PolicyCancellationTracker.Models;

namespace PolicyCancellationTracker.Backend.Tests;

public class UnitTest1
{
    [Fact]
    //This method is a test
    public async Task GetPolicies_ReturnsResult_WhenDatabaseIsEmpty()
    {
        //create fake-in memory database
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        // connect database connection
        using var context = new ApplicationDbContext(options);

        // create controller from app
        var controller = new PoliciesController(context);

        var result = await controller.GetPolicies();

        // if result isn't null - pass
        Assert.NotNull(result);
    }


//add inMemory package -
//dotnet add PolicyCancellationTracker.Backend.Tests/PolicyCancellationTracker.Backend.Tests.csproj package Microsoft.EntityFrameworkCore.InMemory

//find test and run
//dotnet test PolicyCancellationTracker.Backend.Tests/PolicyCancellationTracker.Backend.Tests.csproj

    [Fact]
    public async Task GetPolicies_ReturnsPolicy_WhenDatabaseHasRecord()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabaseWithRecord")
            .Options;

        using var context = new ApplicationDbContext(options);

        //fake policy
        context.CancellationRecords.Add(new CancellationRecord
        {
            Id = 1,
            PolicyNumber = "TEST123",
            InsuredName = "Test User",
            PolicyType = "Personal Auto",
            EffectiveDate = DateTime.Now,
            ExpirationDate = DateTime.Now.AddYears(1),
            CancellationDate = DateTime.Now.AddMonths(6),
            NoticeDate = DateTime.Now.AddMonths(5),
            CancellationReason = "Test Reason",
            AmountDue = 100.00m,
            Status = "Pending Review",
            Notes = "Test note"
        });

        await context.SaveChangesAsync();

        var controller = new PoliciesController(context);

        var result = await controller.GetPolicies();

        Assert.NotNull(result);
    }
}