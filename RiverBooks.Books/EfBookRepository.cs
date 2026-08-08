using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books;

internal class EfBookRepository : IBookRepository
{
  private BookDbContext _dbContext;

  public EfBookRepository(BookDbContext bdContext)
  {
    _dbContext = bdContext;
  }

  public Task AddAsync(Book book)
  {
    _dbContext.Add(book);
    return Task.CompletedTask;
  }

  public Task DeleteAsync(Guid id)
  {
    _dbContext.Remove(id);
    return Task.CompletedTask;
  }

  public async Task<List<Book>> GetAllAsync()
  {
    return await _dbContext.Books.ToListAsync();
  }

  public async Task<Book?> GetAsync(Guid id)
  {
    return await _dbContext.Books.FindAsync(id);
  }

  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();
  }
}
