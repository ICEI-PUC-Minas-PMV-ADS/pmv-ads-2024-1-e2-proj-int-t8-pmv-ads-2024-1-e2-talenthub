using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentHub.Models;
using TalentHub.Data;

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


}
