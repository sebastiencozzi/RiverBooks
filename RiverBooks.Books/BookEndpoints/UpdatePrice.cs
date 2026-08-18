using FastEndpoints;
using RiverBooks.Books.BookEndpoints;
namespace RiverBooks.Books.Endpoints;

internal class UpdatePrice(IBookService bookService) : Endpoint<UpdatePriceRequest>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    var idProp = nameof(UpdatePriceRequest.Id);
    Put($"/books/{{{idProp}}}/price");
    AllowAnonymous();
  }

  public override async Task HandleAsync(UpdatePriceRequest req, CancellationToken ct)
  {
    await _bookService.UpdateBookPrice(req.Id, req.NewPrice);
    await Send.NoContentAsync();
  }
}

