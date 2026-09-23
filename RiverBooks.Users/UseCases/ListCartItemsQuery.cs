using Ardalis.Result;
using MediatR;
using RiverBooks.Users.UserEndpoint;

namespace RiverBooks.Users.UseCases;

public record ListCartItemsQuery(string EmailAddress) : IRequest<Result<List<CartItemDto>>>;

public class ListCartItemsQueryHandler : IRequestHandler<ListCartItemsQuery, Result<List<CartItemDto>>>
{
  private readonly IApplicationUserRepository _applicationUserRepository;

  public ListCartItemsQueryHandler(IApplicationUserRepository applicationUserRepository)
  {
    _applicationUserRepository = applicationUserRepository;
  }
  public async Task<Result<List<CartItemDto>>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
  {
    var userWithCart = await _applicationUserRepository.GetUserWithCartByEmailAsync(request.EmailAddress);
    if (userWithCart == null)
    {
      return Result.Unauthorized();
    }

    return userWithCart.CartItems
      .Select(c => new CartItemDto(c.Id, c.BookId, c.Description, c.Qty, c.UnitPrice))
      .ToList();
  }
}
