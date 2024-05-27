using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentHub.Models;
using TalentHub.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

public class PocController : Controller
{
  private readonly TalentHubContext _context;

  public PocController(TalentHubContext context)
  {
    _context = context;
  }

  // GET: Poc
  public async Task<IActionResult> Index()
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    var projetos = await _context.Projetos.ToListAsync();
    return View(projetos);
  }

  // GET: Poc/Detalhes/5
  public async Task<IActionResult> Detalhes(int? id)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

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

  // GET: Poc/Criar
  public IActionResult Criar()
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    var categoriaOptions = Enum.GetValues(typeof(CategoriaEnum))
       .Cast<CategoriaEnum>()
       .Select(e => new SelectListItem
       {
         Value = e.ToString(),
         Text = e.ToString()
       })
       .ToList();

    ViewBag.CategoriaOptions = categoriaOptions;

    return View();
  }

  // POST: Poc/Criar
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Criar([Bind("NomeProjeto,DescricaoProjeto,Ano,Periodo,Categoria,PalavraChave,UrlRepositorio,UrlAplicacao,Integrantes")] Projeto projeto)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

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

  // GET: Poc/Editar/5
  public async Task<IActionResult> Editar(int? id)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    if (id == null)
    {
      return NotFound();
    }

    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto == null)
    {
      return NotFound();
    }

    var categoriaOptions = Enum.GetValues(typeof(CategoriaEnum))
        .Cast<CategoriaEnum>()
        .Select(e => new SelectListItem
        {
          Value = e.ToString(),
          Text = e.ToString()
        })
        .ToList();

    ViewBag.CategoriaOptions = categoriaOptions;

    return View(projeto);
  }


  // POST: Poc/Editar/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Editar(int id, [Bind("IdProjeto,NomeProjeto,DescricaoProjeto,Ano,Periodo,Categoria,PalavraChave,UrlRepositorio,UrlAplicacao,Integrantes")] Projeto projeto)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

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

  // GET: Poc/Apagar/5
  public async Task<IActionResult> Apagar(int? id)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

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

  // POST: Poc/Apagar/5
  [HttpPost, ActionName("Apagar")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> ApagarConfirmacao(int id)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto != null)
    {
      _context.Projetos.Remove(projeto);
      await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(Index));
  }

}
