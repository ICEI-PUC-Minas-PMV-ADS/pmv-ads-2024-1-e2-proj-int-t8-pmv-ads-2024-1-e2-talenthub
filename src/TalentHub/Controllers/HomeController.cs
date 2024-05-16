using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentHub.Data;
using TalentHub.Models;

namespace TalentHub.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TalentHubContext _context;


    public HomeController(ILogger<HomeController> logger, TalentHubContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var projectCount = await _context.Projetos.CountAsync(p => !p.Deletado);
        ViewBag.ProjectCount = projectCount;

        var projetosMelhorAvaliados = await _context.Projetos
            .Where(p => !p.Deletado)
            .OrderByDescending(p => p.NotaMedia)
            .Take(5)
            .ToListAsync();

        var projetosMaisAcessados = await _context.Projetos
            .Where(p => !p.Deletado)
            .OrderByDescending(p => p.QtdVisualizacoes)
            .Take(5)
            .ToListAsync();

        ViewBag.ProjetosMelhorAvaliados = projetosMelhorAvaliados;
        ViewBag.ProjetosMaisAcessados = projetosMaisAcessados;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
