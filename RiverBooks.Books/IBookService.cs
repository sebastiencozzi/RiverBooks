namespace RiverBooks.Books;

internal interface IBookService
{
  Task<List<BookDto>> ListBooksAsync();
  Task CreateBookAsync(BookDto newBook);
  Task DeleteBookAsynx(Guid id);
  Task<BookDto> GetBookAsync(Guid id);
  Task UpdateBookPrice(Guid id, decimal newPrice);
}
