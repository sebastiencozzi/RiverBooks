namespace RiverBooks.Books
{
    internal interface IBookService
    {
        IEnumerable<BookDto> ListBooks();
    }

    internal class BookService : IBookService
    {
        public IEnumerable<BookDto> ListBooks()
        {
            return [
                new BookDto(Guid.NewGuid(), "Abb", "Gérard"),
                new BookDto(Guid.NewGuid(), "bbb", "Bouchard"),
                new BookDto(Guid.NewGuid(), "Ccc", "Charlie"),
                new BookDto(Guid.NewGuid(), "Sarteck", "Bravo"),
                ];

        }
    }
    public record BookDto(Guid id, string Title, string Author);
}