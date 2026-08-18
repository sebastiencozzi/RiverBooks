using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books.Data;

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

  public async Task DeleteAsync(Guid id)
  {
    var book = await GetAsync(id);
    if (book is null)
      return;
    _dbContext.Remove(book);
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
