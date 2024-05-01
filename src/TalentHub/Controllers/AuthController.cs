using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentHub.Models;
using TalentHub.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

public class AuthController : Controller
{
  private readonly TalentHubContext _context;

  public AuthController(TalentHubContext context)
  {
    _context = context;
  }

  // GET: Auth
  public IActionResult Index()
  {
    return View();
  }

  // GET: Auth/LoginWithGoogle
  [HttpGet("Auth/LoginWithGoogle")]
  public IActionResult LoginWithGoogle()
  {
    var authenticationProperties = new AuthenticationProperties
    {
      RedirectUri = Url.Action(nameof(GoogleResponse))
    };
    return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);
  }

  // GET: Auth/GoogleResponse
  [HttpGet("Auth/GoogleResponse")]
  public async Task<IActionResult> GoogleResponse()
  {
    var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    if (!authenticateResult.Succeeded)
    {
      return RedirectToAction("Index", "Auth");
    }

    return Redirect("/");
  }
}
