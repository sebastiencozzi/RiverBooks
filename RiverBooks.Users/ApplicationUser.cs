using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users;

public class ApplicationUser : IdentityUser
{
  public string FullName { get; set; } = string.Empty;

  private readonly List<CartItem> _cartItems = new();
  public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

  public void AddItemToCart(CartItem item)
  {
    Guard.Against.Null(item);
    var existingBook = _cartItems.SingleOrDefault(b => b.Id == item.Id);
    if (existingBook != null)
    {
      //Todo : handle price update
      existingBook.UpdateQuantity(existingBook.Qty + item.Qty);
    }
    _cartItems.Add(item);
  }
}

public class CartItem
{
  public Guid Id { get; private set; } = Guid.NewGuid();
  public Guid BookId { get; private set; }
  public string Description { get; private set; } = string.Empty;
  public int Qty { get; private set; }
  public decimal UnitPrice { get; private set; }
  public CartItem(Guid bookId, string description, int qty, decimal unitPrice)
  {
    BookId = bookId;
    Description = description;
    Qty = qty;
    UnitPrice = unitPrice;
  }

  internal void UpdateQuantity(int newQuantity)
  {
    Qty = newQuantity;

  }
}
