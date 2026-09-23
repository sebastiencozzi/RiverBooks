using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCases;

public record AddItemToCartCommand(Guid BookId, int Quantity, string emailAddress)
  : IRequest<Result>;

public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, Result>
{
  private IApplicationUserRepository _applicationUserRepository;

  public AddItemToCartHandler(IApplicationUserRepository applicationUserRepository)
  {
    _applicationUserRepository = applicationUserRepository;
  }
  public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
  {
    var user = await _applicationUserRepository.GetUserWithCartByEmailAsync(request.emailAddress);
    if (user == null)
    {
      return Result.Unauthorized();
    }
    var newCartItem = new CartItem(request.BookId, "todo", request.Quantity, 99.99m /*Todo*/ );
    await _applicationUserRepository.SaveChangesAsync();
    return new Result();
  }
}
