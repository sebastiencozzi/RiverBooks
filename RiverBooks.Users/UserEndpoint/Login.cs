using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users.UserEndpoint;
public record UserLoginRequest(string Email, string Password);
internal class Login : Endpoint<UserLoginRequest>
{
  private UserManager<ApplicationUser> _userManager;

  public Login(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }
  public override void Configure()
  {
    Post("/users/login");
    AllowAnonymous();
  }


  public override async Task HandleAsync(UserLoginRequest req, CancellationToken ct)
  {
    var user = await _userManager.FindByEmailAsync(req.Email);
    if (user == null)
    {
      await Send.UnauthorizedAsync();
      return;
    }
    var loginOk = await _userManager.CheckPasswordAsync(user, req.Password);
    if (!loginOk)
    {
      await Send.UnauthorizedAsync();
      return;
    }
    var token = JwtBearer.CreateToken(
     o =>
     {
       o.SigningKey = Config["Auth:JwtSecret"]!;
       o.ExpireAt = DateTime.UtcNow.AddHours(1);
       o.User.Claims.Add(("EmailAddress", req.Email));
     });

    await Send.OkAsync(token);
  }
}
