using FastEndpoints;
using RiverBooks.Books.BookEndpoints;
namespace RiverBooks.Books.Endpoints;

internal class GetById(IBookService bookService) : Endpoint<GetByIdRequest, BookDto>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    var idProp = nameof(GetByIdRequest.IdBook);
    Get($"/book/{{{idProp}}}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetByIdRequest req, CancellationToken ct)
  {
    var book = await _bookService.GetBookAsync(req.IdBook);
    await Send.OkAsync(book);
  }
}
