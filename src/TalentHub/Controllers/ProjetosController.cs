using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentHub.Models;
using System.Linq;
using TalentHub.Data;

public class ProjetosController : Controller
{
  private readonly TalentHubContext _context;

  public ProjetosController(TalentHubContext context)
  {
    _context = context;
  }

  // GET: Projetos
  public async Task<IActionResult> Index()
  {
    var projetos = await _context.Projetos.ToListAsync();
    return View(projetos);
  }

  // GET: Projetos/Gerenciar
  public async Task<IActionResult> Gerenciar()
  {
    var projetos = await _context.Projetos.ToListAsync();
    return View(projetos);
  }

  // GET: Projetos/Detalhes/1
  public async Task<IActionResult> Detalhes(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var projeto = await _context.Projetos
        .FirstOrDefaultAsync(m => m.IdProjeto == id);
    if (projeto == null)
    {
      return NotFound();
    }

    return View(projeto);
  }

  // GET: Projetos/Criar
  public IActionResult Criar()
  {
    return View();
  }

  // POST: Projetos/Criar
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Criar([Bind("NomeProjeto,UrlRepositorio,UrlAplicacao,Integrantes")] Projeto projeto)
  {
    if (!ModelState.IsValid)
    {
      foreach (var entry in ModelState)
      {
        if (entry.Value.Errors.Count > 0)
        {
          Console.WriteLine($"Error in {entry.Key}:");
          foreach (var error in entry.Value.Errors)
          {
            Console.WriteLine($"- {error.ErrorMessage}");
          }
        }
      }
      return View(projeto);
    }

    _context.Add(projeto);
    try
    {
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    catch (Exception ex)
    {
      ModelState.AddModelError("", "Não foi possível salvar os dados. Detalhes do erro: " + ex.Message);
    }

    return View(projeto);
  }

  // GET: Projetos/Editar/5
  public async Task<IActionResult> Editar(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto == null)
    {
      return NotFound();
    }
    return View(projeto);
  }


  // POST: Projetos/Edit/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Editar(int id, [Bind("IdProjeto,NomeProjeto,UrlRepositorio,UrlAplicacao,Integrantes")] Projeto projeto)
  {
    if (id != projeto.IdProjeto)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(projeto);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_context.Projetos.Any(e => e.IdProjeto == projeto.IdProjeto))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction(nameof(Index));
    }
    return View(projeto);
  }

  // GET: Projetos/Apagar/5
  public async Task<IActionResult> Apagar(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var projeto = await _context.Projetos
        .FirstOrDefaultAsync(m => m.IdProjeto == id);
    if (projeto == null)
    {
      return NotFound();
    }

    return View(projeto);
  }

  // POST: Projetos/Apagar/5
  [HttpPost, ActionName("Apagar")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> ApagarConfirmacao(int id)
  {
    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto != null)
    {
      _context.Projetos.Remove(projeto);
      await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> AvaliarProjeto(int id, int rating, string comments)
  {
    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto == null)
    {
      return NotFound();
    }

    return RedirectToAction(nameof(Detalhes), new { id = id });
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> SalvarAnotacao(int id, string annotation)
  {
    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto == null)
    {
      return NotFound();
    }

    return RedirectToAction(nameof(Detalhes), new { id = id });
  }

  // GET: Projetos/ResultadosBusca
  public async Task<IActionResult> ResultadosBusca()
  {
    var projetos = await _context.Projetos.ToListAsync();
    return View(projetos);
  }


  // POST: Projetos/Busca
  [HttpPost]
  public async Task<IActionResult> Busca(string searchTerm)
  {
    ViewData["SearchTerm"] = searchTerm;
    var projetos = await _context.Projetos.ToListAsync();
    return View("ResultadosBusca", projetos);
  }



}
