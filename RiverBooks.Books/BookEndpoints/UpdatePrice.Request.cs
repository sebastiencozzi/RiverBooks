namespace RiverBooks.Books.BookEndpoints;

public class UpdatePriceRequest
{
  public Guid Id { get; set; }
  public decimal NewPrice { get; set; }
}
