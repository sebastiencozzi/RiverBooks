using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.BookEndpoints;
using RiverBooks.Books.Endpoints;
using RiverBooks.Books.Tests.Endpoints;

namespace RiverBooks.Books.Tests;

public class GetByIdTest(Fixture fixture) :
  TestBase<Fixture>()
{
  [Theory]
  [InlineData("733ba805-73cc-4f9c-9c23-2cd0e549b3f3", "book1")]
  [InlineData("19fce2dd-7e7a-49aa-8e73-f1780286a9e5", "book2")]
  [InlineData("f1b9b9f7-f300-48ef-b3b1-826211e3c319", "book3")]
  public async Task GetBookAsync(string bGuid, string title)
  {
    GetByIdRequest request = new GetByIdRequest()
    {
      IdBook = Guid.Parse(bGuid)
    };
    var response = await fixture.Client.GETAsync<GetById, GetByIdRequest, BookDto>(request);
    response.Response.EnsureSuccessStatusCode();
    response.Result.Title.Should().Be(title);
  }

  [Fact]

  public async Task BookNotFoundAsync()
  {
    GetByIdRequest request = new GetByIdRequest()
    {
      IdBook = Guid.Empty
    };
    var response = await fixture.Client.GETAsync<GetById, GetByIdRequest, BookDto>(request);
    response.Response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
  }
}
