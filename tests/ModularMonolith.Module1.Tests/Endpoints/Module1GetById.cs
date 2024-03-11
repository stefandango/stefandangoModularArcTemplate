using FastEndpoints;
using FastEndpoints.Testing;

using FluentAssertions;

using ModularMonolith.Module1.Endpoints;

using Xunit.Abstractions;

namespace ModularMonolith.Module1.Tests.Endpoints;

public class Module1GetById(Fixture fixture, ITestOutputHelper outputHelper) : TestBase<Fixture>
{
    public ITestOutputHelper OutputHelper { get; } = outputHelper;

    [Theory]
    [InlineData("04069dc5-c48e-4171-8828-32dd98b074b0", "Object_3")]
    [InlineData("d595a08e-4675-434a-9c74-e6d9a76d6d91", "Object_2")]
    public async Task ReturnsExpectedModule1GivenIdAsync(string validId, string name)
    {
        // Arrange
        Guid id = Guid.Parse(validId);
        var request = new GetModule1ByIdRequest {Id = id};
        
        // Act 
        var testResult = await fixture.Client.GETAsync<GetById, GetModule1ByIdRequest, Module1Dto>(request);
        testResult.Response.EnsureSuccessStatusCode();
        
        //Assert
        testResult.Result.Name.Should().Be(name);
    }
    
}