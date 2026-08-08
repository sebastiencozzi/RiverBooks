namespace RiverBooks.Books;

public record BookDto(Guid Id, string Title, string Author, decimal Price, string Description)
{
  internal static BookDto FromEntity(Book book)
  {
    return new BookDto(book.Id, book.Title, book.Author, book.Price, book.Description);
  }
  internal Book ToEntity()
  {
    return new Book(Id, Title, Author, Description, Price);
  }
}
