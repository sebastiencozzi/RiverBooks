using FastEndpoints;
namespace RiverBooks.Books;

internal class GetBookByIdEndpoint(IBookService bookService) : Endpoint<GetBookByIdRequest, GetBookByIdResponse>
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
