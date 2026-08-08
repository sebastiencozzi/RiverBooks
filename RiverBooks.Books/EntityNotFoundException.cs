
namespace RiverBooks.Books;

[Serializable]
internal class EntityNotFoundException<T> : Exception
{
  public EntityNotFoundException()
  {
  }

  public EntityNotFoundException(string? message) : base(message)
  {
  }

  public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
  {
  }
}