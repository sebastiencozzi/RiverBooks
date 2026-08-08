using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
  public static IServiceCollection RegisterBooksServices(
    this IServiceCollection serviceCollections,
    ConfigurationManager configurationManager)
  {
    serviceCollections.AddScoped<IBookService, BookService>();
    serviceCollections.AddScoped<IBookRepository, EfBookRepository>();

    var connectionString = configurationManager.GetConnectionString("BooksConnectionString");
    serviceCollections.AddDbContext<BookDbContext>(option =>
    option.UseSqlServer(connectionString));
    return serviceCollections;
  }
}
