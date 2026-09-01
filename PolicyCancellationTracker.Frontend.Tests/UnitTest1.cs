using Bunit;
using Xunit;
using PolicyCancellationTracker.Components.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace PolicyCancellationTracker.Frontend.Tests;

public class UnitTest1
{
    [Fact]
    public void HomePage_DisplaysCancellationDashboard()
    {
        // Create fake environment for Razor component
        using var context = new BunitContext();

        // Add HttpClientFactory because Home.razor needs it
        context.Services.AddHttpClient("PolicyApi", client =>
        {
            client.BaseAddress = new Uri("http://localhost");
        });

        // Render Home page
        var component = context.Render<Home>();

        // Check that home page displays the dashboard heading
        Assert.Contains("Cancellation Dashboard", component.Markup);
    }
}

// Connect frontend test project to main app
// dotnet add PolicyCancellationTracker.Frontend.Tests/PolicyCancellationTracker.Frontend.Tests.csproj reference PolicyCancellationTracker/PolicyCancellationTracker/PolicyCancellationTracker.csproj

// Add bUnit package so we can test Razor frontend components
// dotnet add PolicyCancellationTracker.Frontend.Tests/PolicyCancellationTracker.Frontend.Tests.csproj package bunit