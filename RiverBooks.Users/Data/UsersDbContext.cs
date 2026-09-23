using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Users.Data;

public class UsersDbContext : IdentityDbContext
{
  public DbSet<ApplicationUser> ApplicationUsers { get; set; }
  public UsersDbContext(DbContextOptions<UsersDbContext> option) : base(option)
  {

  }
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.HasDefaultSchema("Users");
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(builder);
  }
  protected override void ConfigureConventions(
    ModelConfigurationBuilder configurationBuilder)
  {
    base.ConfigureConventions(configurationBuilder);
    configurationBuilder.Properties<decimal>()
      .HavePrecision(18, 6);
  }
}
