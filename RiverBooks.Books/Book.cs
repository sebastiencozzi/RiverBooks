using Ardalis.GuardClauses;

namespace RiverBooks.Books;
internal class Book
{
  public Guid Id { get; private set; } = Guid.NewGuid();
  public string Title { get; private set; } = string.Empty;
  public string Author { get; private set; } = string.Empty;
  public decimal Price { get; private set; }
  public string Description { get; private set; } = String.Empty;

  internal Book(Guid id, string title, string description, string author, decimal price)
  {
    Id = Guard.Against.Default(id);
    Title = Guard.Against.NullOrWhiteSpace(title);
    Description = Guard.Against.NullOrWhiteSpace(description);
    Author = Guard.Against.NullOrWhiteSpace(author);
    Price = Guard.Against.NegativeOrZero(price);
  }

  public void UpdatePrice(decimal newPrice)
  {
    Price = Guard.Against.NegativeOrZero(newPrice);
  }


}
