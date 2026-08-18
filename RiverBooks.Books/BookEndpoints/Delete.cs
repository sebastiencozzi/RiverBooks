using FastEndpoints;
namespace RiverBooks.Books.Endpoints;

internal class Delete(IBookService bookService) : Endpoint<DeleteRequest>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    var idProp = nameof(DeleteRequest.Id);
    Delete($"/books/{{{idProp}}}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
  {
    await _bookService.DeleteBookAsync(req.Id);
    await Send.NoContentAsync();
  }
}

