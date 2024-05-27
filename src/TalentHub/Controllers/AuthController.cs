using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentHub.Models;
using TalentHub.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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
    var state = Guid.NewGuid().ToString("N");
    HttpContext.Session.SetString("authState", state);

    var authenticationProperties = new AuthenticationProperties
    {
      RedirectUri = Url.Action(nameof(GoogleResponse)),
    };
    return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);
  }

  public async Task<IActionResult> GoogleResponse()
  {

    var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    if (!authenticateResult.Succeeded)
    {
      return RedirectToAction("Index", "Auth");
    }

    var claimsIdentity = authenticateResult.Principal.Identities.FirstOrDefault();
    if (claimsIdentity == null)
    {
      TempData["ErrorMessage"] = "Não foi possível obter as informações do usuário";
      return RedirectToAction("Index", "Auth");
    }

    var email = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;
    var nome = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

    if (email == null)
    {
      TempData["ErrorMessage"] = "Não foi possível obter as informações do usuário";
      return RedirectToAction("Index", "Auth");
    }

    var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    if (usuario == null)
    {
      usuario = new Usuario
      {
        NomeUsuario = nome,
        Email = email,
        Projetos = new List<Projeto>(),
        Avaliacoes = new List<Avaliacao>(),
        Anotacoes = new List<Anotacao>()
      };
      _context.Usuarios.Add(usuario);
      await _context.SaveChangesAsync();
    }

    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, nome),
            new Claim(ClaimTypes.Email, email),
            new Claim("IdUsuario", usuario.IdUsuario.ToString())
        };

    await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

    return Redirect("/");
  }

  [HttpPost]
  public async Task<IActionResult> Logout()
  {
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return RedirectToAction("Index", "Home");
  }
}
