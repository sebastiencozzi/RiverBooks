using FastEndpoints;
using RiverBooks.Books.BookEndpoints;
namespace RiverBooks.Books.Endpoints;

internal class ListBooks(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    Get("/books");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct = default)
  {
    var books = await _bookService.ListBooksAsync();
    await Send.OkAsync(new ListBooksResponse(books));
  }
}
