using FastEndpoints;
namespace RiverBooks.Books;

internal class CreateBookEndpoint(IBookService bookService) : Endpoint<CreateBookRequest, BookDto>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    Post($"/books");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
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

    await Send.CreatedAtAsync<GetBookByIdEndpoint>(new { newBookDto.Id },
      newBookDto);
  }
}
