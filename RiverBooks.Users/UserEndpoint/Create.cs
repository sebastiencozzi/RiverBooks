using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users.UserEndpoint;
internal class Create : Endpoint<CreateUserRequest>
{
  private UserManager<ApplicationUser> _userManager;

  public Create(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  public override void Configure()
  {
    Post("/users");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
  {
    var appUser = new ApplicationUser()
    {
      Email = req.Email,
      UserName = req.Email,
    };

    var ret = await _userManager.CreateAsync(appUser, req.Password);
    if (ret.Succeeded)
      await Send.OkAsync();
    else
      await Send.ErrorsAsync();
  }
}

public record CreateUserRequest(string Email, string Password);
