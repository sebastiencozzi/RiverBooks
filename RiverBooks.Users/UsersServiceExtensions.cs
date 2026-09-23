using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.Users.Data;
using RiverBooks.Users.UseCases;
using Serilog;

namespace RiverBooks.Users;

public static class UsersServiceExtensions
{
  public static IServiceCollection RegisterUsersServices(
    this IServiceCollection serviceCollections,
    ConfigurationManager configurationManager,
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies)
  {


    var connectionString = configurationManager.GetConnectionString("UsersConnectionString");
    serviceCollections.AddDbContext<UsersDbContext>(option =>
    option.UseSqlServer(connectionString));

    serviceCollections.AddIdentityCore<ApplicationUser>()
      .AddEntityFrameworkStores<UsersDbContext>();

    serviceCollections.AddScoped<IApplicationUserRepository, EfApplicationUserRepository>();

    mediatRAssemblies.Add(typeof(UsersServiceExtensions).Assembly);
    logger.Information("{Module} module services registered", "Users");
    return serviceCollections;
  }
}

