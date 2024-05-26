using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentHub.Models;
using TalentHub.Data;
using System.Linq;
using System.Threading.Tasks;

public class AnotacoesController : Controller
{
  private readonly TalentHubContext _context;

  public AnotacoesController(TalentHubContext context)
  {
    _context = context;
  }

  // GET: Anotacoes/Index
  public async Task<IActionResult> Index(int? pageNumber)
  {
    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);
    var anotacoes = _context.Anotacoes
                            .Include(a => a.Projeto)
                            .Where(a => a.IdUsuario == usuarioId)
                            .AsNoTracking();

    int pageSize = 10;
    return View(await PaginatedList<Anotacao>.CreateAsync(anotacoes, pageNumber ?? 1, pageSize));
  }

  // GET: Anotacoes/Apagar/5
  public async Task<IActionResult> Apagar(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);
    var anotacao = await _context.Anotacoes
        .Include(a => a.Projeto)
        .FirstOrDefaultAsync(m => m.Id == id && m.IdUsuario == usuarioId);

    if (anotacao == null)
    {
      return NotFound();
    }

    return View(anotacao);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> ApagarConfirmacao(int id)
  {
    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);
    var anotacao = await _context.Anotacoes
        .FirstOrDefaultAsync(m => m.Id == id && m.IdUsuario == usuarioId);

    if (anotacao != null)
    {
      _context.Anotacoes.Remove(anotacao);
      await _context.SaveChangesAsync();
    }

    return RedirectToAction(nameof(Index));
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> EditarAnotacao(int? id, string annotation)
  {
    if (id == null)
    {
      return NotFound();
    }

    var anotacao = await _context.Anotacoes.FindAsync(id);
    if (anotacao == null)
    {
      return NotFound();
    }

    anotacao.TextoAnotacao = annotation;
    _context.Update(anotacao);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }

}