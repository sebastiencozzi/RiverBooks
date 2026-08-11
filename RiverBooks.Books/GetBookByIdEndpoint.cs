using FastEndpoints;
namespace RiverBooks.Books;
internal class DeleteBookEndpoint(IBookService bookService) : Endpoint<DeleteBookRequest>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    string idProp = nameof(GetBookByIdRequest.IdBook);
    Get($"/books/{{{idProp}}}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetBookByIdRequest req, CancellationToken ct)
  {
    var book = await _bookService.GetBookAsync(req.IdBook);
    await Send.OkAsync(book);
  }
}

internal class DeleteBookRequest
{
  internal Guid Id { set; get; }
}

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
