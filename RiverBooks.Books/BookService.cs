

namespace RiverBooks.Books;

internal class BookService(IBookRepository bookRepository) : IBookService
{
  public async Task CreateBookAsync(BookDto newBook)
  {
    await bookRepository.AddAsync(newBook.ToEntity());
    await bookRepository.SaveChangesAsync();
  }

  public async Task DeleteBookAsync(Guid id)
  {
    await bookRepository.DeleteAsync(id);
    await bookRepository.SaveChangesAsync();
  }

  public async Task<BookDto> GetBookAsync(Guid id)
  {
    var book = await bookRepository.GetAsync(id);
    if (book == null)
      throw new EntityNotFoundException<Book>();
    return new BookDto(book.Id, book.Title, book.Author, book.Price, book.Description);
  }

  public async Task<List<BookDto>> ListBooksAsync()
  {
    var bookList = await bookRepository.GetAllAsync();
    return bookList
      .Select(book => BookDto.FromEntity(book))
      .ToList();
  }

  public async Task UpdateBookPrice(Guid id, decimal newPrice)
  {
    var book = await bookRepository.GetAsync(id);

    //Todo : handle exception globaly
    if (book == null)
      throw new EntityNotFoundException<Book>();
    book.UpdatePrice(newPrice);
    await bookRepository.SaveChangesAsync();
  }
}
