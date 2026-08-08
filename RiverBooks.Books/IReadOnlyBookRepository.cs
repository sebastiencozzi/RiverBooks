namespace RiverBooks.Books;

internal interface IReadOnlyBookRepository
{
  Task<List<Book>> GetAllAsync();
  Task<Book?> GetAsync(Guid id);
}
