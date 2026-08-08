using FastEndpoints;
namespace RiverBooks.Books;

internal class GetBookByIdEndpoint(IBookService bookService) : Endpoint<GetBookByIdRequest, BookDto>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    string idProp = nameof(GetBookByIdRequest.IdBook);
    Get($"/book/{{{idProp}}}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetBookByIdRequest req, CancellationToken ct)
  {
    var book = await _bookService.GetBookAsync(req.IdBook);
    await Send.OkAsync(book);
  }
}
