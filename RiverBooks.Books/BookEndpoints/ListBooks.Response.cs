namespace RiverBooks.Books.BookEndpoints;

public class ListBooksResponse
{

    public List<BookDto> Books { get; set; }

    public ListBooksResponse(List<BookDto> books)
    {
        if (books is null)
        {
            books = new List<BookDto>();
        }
        Books = books;
    }
}