namespace RiverBooks.Books.BookEndpoints;

internal class UpdatePriceRequest
{
  public Guid Id { get; set; }
  public decimal NewPrice { get; set; }
}
