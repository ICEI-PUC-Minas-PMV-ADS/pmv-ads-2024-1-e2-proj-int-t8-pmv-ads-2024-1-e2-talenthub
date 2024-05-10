using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TalentHub.Models;

namespace TalentHub.Controllers;

public class TermosController : Controller
{
    private readonly ILogger<TermosController> _logger;

    public TermosController(ILogger<TermosController> logger)
    {
        _logger = logger;
    }

    public IActionResult PoliticaDePrivacidade()
    {
        return View();
    }

    public IActionResult TermosDeUso()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
