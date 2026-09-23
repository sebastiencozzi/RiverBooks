using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Books.Data;
using Serilog;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
  public static IServiceCollection RegisterBooksServices(
    this IServiceCollection serviceCollections,
    ConfigurationManager configurationManager,
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies)
  {
    serviceCollections.AddScoped<IBookService, BookService>();
    serviceCollections.AddScoped<IBookRepository, EfBookRepository>();

    var connectionString = configurationManager.GetConnectionString("BooksConnectionString");
    serviceCollections.AddDbContext<BookDbContext>(option =>
    option.UseSqlServer(connectionString));
    logger.Information("{Module} module services registered", "Book");
    return serviceCollections;
  }
}
