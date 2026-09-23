namespace RiverBooks.Users.UserEndpoint;

public record AddItemRequest(Guid BookId, int Quantity);
