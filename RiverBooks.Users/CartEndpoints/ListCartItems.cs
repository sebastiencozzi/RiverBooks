using System.Security.Claims;
using Ardalis.Result;
using FastEndpoints;
using MediatR;
using RiverBooks.Users.UseCases;

namespace RiverBooks.Users.UserEndpoint;

internal class ListCartItems : EndpointWithoutRequest<ListCartItemsResponse>
{
  private readonly IMediator _mediator;

  public ListCartItems(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("/cart");
    Claims("EmailAddress");
    //AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var email = User.FindFirstValue("EmailAddress");
    var query = new ListCartItemsQuery(email!);
    var result = await _mediator.Send(query);
    if (result.Status == ResultStatus.Unauthorized)
    {
      await Send.UnauthorizedAsync();
    }
    else
    {
      var cartResponse = new ListCartItemsResponse()
      {
        cartItems = result.Value
      };
      await Send.OkAsync(cartResponse);
    }
  }
}

public record CartItemDto(Guid Id, Guid BookId, string Description, int Quantity, decimal UnitPrice);
