using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books
{
    public static class BookServiceExtensions
    {
        public static void RegisterBooksServices(this IServiceCollection serviceCollections)
        {
            serviceCollections.AddScoped<IBookService, BookService>();
        }
    }
}
