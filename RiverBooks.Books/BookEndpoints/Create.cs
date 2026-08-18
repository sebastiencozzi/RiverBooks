using FastEndpoints;
using RiverBooks.Books.BookEndpoints;
namespace RiverBooks.Books.Endpoints;

internal class Create(IBookService bookService) : Endpoint<CreateRequest, BookDto>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    Post($"/books");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateRequest req, CancellationToken ct)
  {
    var newBookDto = new BookDto(
      req.Id == Guid.Empty ? Guid.NewGuid() : req.Id,
      req.Title,
      req.Author,
      req.Price,
      req.Description
      );

    //todo : see how to handle already existing id case

    await _bookService.CreateBookAsync(newBookDto);

    await Send.CreatedAtAsync<GetById>(new { newBookDto.Id },
      newBookDto);
  }
}
