namespace RiverBooks.Books;

public class ListBooksResponse
{

    public List<BookDto> Books { get; set; }

    public ListBooksResponse(List<BookDto> books)
    {
        if (books is null)
        {
            books = new List<BookDto>();
        }
        this.Books = books;
    }
}