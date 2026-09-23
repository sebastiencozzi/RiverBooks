namespace RiverBooks.Books.Tests.Endpoints;

public class Fixture() : FastEndpoints.Testing.AppFixture<Program>
{
  protected override ValueTask SetupAsync()
  {
    Client = CreateClient();
    return base.SetupAsync();
  }

  protected override ValueTask TearDownAsync()
  {
    Client.Dispose();
    return base.TearDownAsync();
  }
}

