using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace RiverBooks.Books;

public static class BooksEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("/books", (IBookService bookService) =>
        {
            return bookService.ListBooks();
        });
    }
    public static void RegisterBooksServices(this IServiceCollection serviceCollections)
    {
        serviceCollections.AddScoped<IBookService, BookService>();
    }
}

