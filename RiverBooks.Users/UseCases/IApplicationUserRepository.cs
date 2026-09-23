namespace RiverBooks.Users.UseCases;

public interface IApplicationUserRepository
{
  Task<ApplicationUser> GetUserWithCartByEmailAsync(string email);
  Task SaveChangesAsync();
}
