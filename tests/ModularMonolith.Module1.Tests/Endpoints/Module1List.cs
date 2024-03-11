using FastEndpoints;
using FastEndpoints.Testing;

using FluentAssertions;

using ModularMonolith.Module1.Endpoints;

using Xunit.Abstractions;
using Xunit.Sdk;

namespace ModularMonolith.Module1.Tests.Endpoints;
public class Module1List (Fixture fixture, ITestOutputHelper outputHelper) : TestBase<Fixture>
{
    public ITestOutputHelper OutputHelper { get; } = outputHelper;

    [Fact]
    public async Task ReturnsThreeModule1ItemsAsync()
    {
        //Arrange
        
        // Act
        var testResult = await fixture.Client.GETAsync<List, ListModule1Response>();
        
        //Assert
        testResult.Response.EnsureSuccessStatusCode();
        testResult.Result.Items.Count.Should().Be(3);
    }

}
