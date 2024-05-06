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

  // GET: Projetos/Manage
  public async Task<IActionResult> Manage()
  {
    var projetos = await _context.Projetos.ToListAsync();
    return View(projetos);
  }

  // GET: Projetos/Details/1
  public async Task<IActionResult> Details(int? id)
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

  // GET: Projetos/Create
  public IActionResult Create()
  {
    return View();
  }

  // POST: Projetos/Create
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create([Bind("NomeProjeto,UrlRepositorio,UrlAplicacao,Integrantes")] Projeto projeto)
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

  // GET: Projetos/Edit/5
  public async Task<IActionResult> Edit(int? id)
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
  public async Task<IActionResult> Edit(int id, [Bind("IdProjeto,NomeProjeto,UrlRepositorio,UrlAplicacao,Integrantes")] Projeto projeto)
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

  // GET: Projetos/Delete/5
  public async Task<IActionResult> Delete(int? id)
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

  // POST: Projetos/Delete/5
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto != null)
    {
      _context.Projetos.Remove(projeto);
      await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
  }

}
