using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.BookEndpoints;
using RiverBooks.Books.Endpoints;
using RiverBooks.Books.Tests.Endpoints;

namespace RiverBooks.Books.Tests;
public class BookList(Fixture fixture) :
  TestBase<Fixture>()
{
  [Fact]
  public async Task ReturnsBooksAsync()
  {
    var response = await fixture.Client.GETAsync<ListBooks, ListBooksResponse>();
    response.Response.EnsureSuccessStatusCode();
    response.Result.Books.Count.Should().Be(3);
  }
}
