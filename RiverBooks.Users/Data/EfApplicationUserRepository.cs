using Microsoft.EntityFrameworkCore;
using RiverBooks.Users.UseCases;

namespace RiverBooks.Users.Data;
internal class EfApplicationUserRepository : IApplicationUserRepository
{
  private readonly UsersDbContext _context;

  public EfApplicationUserRepository(UsersDbContext context)
  {
    _context = context;
  }
  public async Task<ApplicationUser> GetUserWithCartByEmailAsync(string email)
  {
    return await _context.ApplicationUsers
      .Include(user => user.CartItems)
      .SingleAsync(u => u.Email == email);
  }

  public async Task SaveChangesAsync()
  {
    await _context.SaveChangesAsync();
  }
}
