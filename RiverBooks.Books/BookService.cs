namespace RiverBooks.Books
{
    internal class BookService : IBookService
    {
        public List<BookDto> ListBooks()
        {
            return [
                new BookDto(Guid.NewGuid(), "Abb", "Gérard"),
                new BookDto(Guid.NewGuid(), "bbb", "Bouchard"),
                new BookDto(Guid.NewGuid(), "Ccc", "Charlie"),
                new BookDto(Guid.NewGuid(), "Sarteck", "Bravo"),
                ];

        }
    }
}