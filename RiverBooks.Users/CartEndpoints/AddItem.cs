using System.Security.Claims;
using Ardalis.Result;
using FastEndpoints;
using MediatR;
using RiverBooks.Users.UseCases;

namespace RiverBooks.Users.UserEndpoint;

internal class AddItem : Endpoint<AddItemRequest>
{
  private IMediator _mediator;

  public AddItem(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post("/cart");
    //Claims("EmailAddress");
    AllowAnonymous();
  }

  public override async Task HandleAsync(AddItemRequest req, CancellationToken ct)
  {

    var authHeader = HttpContext.Request.Headers.Authorization.ToString();

    var isAuthenticated =
        HttpContext.User.Identity?.IsAuthenticated;

    var claims = HttpContext.User.Claims
        .Select(c => new { c.Type, c.Value })
        .ToList();
    var emailAddress = User.FindFirstValue("EmailAddress");
    var command = new AddItemToCartCommand(req.BookId, req.Quantity, emailAddress!);
    var result = await _mediator.Send(command, ct);

    if (result.Status == ResultStatus.Ok)
      await Send.OkAsync();
    else
      await Send.ErrorsAsync();
  }
}
