using Xunit.Abstractions;
using FastEndpoints.Testing;

namespace ModularMonolith.Module1.Tests.Endpoints;

public class Fixture(IMessageSink messageSink) : AppFixture<Program>(messageSink)
{
    protected override Task SetupAsync()
    {
        Client = CreateClient();
        return Task.CompletedTask;
    }

    protected override Task TearDownAsync()
    {
        Client.Dispose();
        return base.TearDownAsync();
    }
}