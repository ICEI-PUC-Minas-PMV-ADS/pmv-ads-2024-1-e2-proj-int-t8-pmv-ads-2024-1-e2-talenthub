using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentHub.Models;
using TalentHub.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ProjetosController : Controller
{
  private readonly TalentHubContext _context;
  private readonly GitHubService _gitHubService;

  public ProjetosController(TalentHubContext context, GitHubService gitHubService)
  {
    _context = context;
    _gitHubService = gitHubService;
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
                                .Include(p => p.Anotacoes)
                                .FirstOrDefaultAsync(m => m.IdProjeto == id);

    if (projeto == null)
    {
      return NotFound();
    }

    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);
    var anotacao = projeto.Anotacoes.FirstOrDefault(a => a.IdUsuario == usuarioId);

    ViewBag.AnnotacaoExistente = anotacao;

    var cookieKey = $"projeto-{id}-visualizado";
    if (!Request.Cookies.ContainsKey(cookieKey))
    {
      Response.Cookies.Append(cookieKey, "true", new CookieOptions
      {
        Expires = DateTime.Now.AddYears(1)
      });
      projeto.QtdVisualizacoes++;
      _context.Update(projeto);
      await _context.SaveChangesAsync();
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
  public async Task<IActionResult> Criar([Bind("NomeProjeto,UrlRepositorio,UrlAplicacao,Integrantes,Ano,Periodo,PalavraChave,DescricaoProjeto,Categoria,InformacoesContato")] Projeto projeto)
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
      return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
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
  public async Task<IActionResult> Editar(int id, [Bind("IdProjeto,NomeProjeto,DescricaoProjeto,Ano,Periodo,Categoria,PalavraChave,UrlRepositorio,UrlAplicacao,Integrantes")] Projeto projeto)
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

    var projeto = await _context.Projetos.FirstOrDefaultAsync(m => m.IdProjeto == id);
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
    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);

    // Verificar se o projeto existe
    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto == null)
    {
      return NotFound();
    }

    // Procurar uma anotação existente para o projeto e usuário
    var anotacaoExistente = await _context.Anotacoes
        .FirstOrDefaultAsync(a => a.IdProjeto == projeto.IdProjeto && a.IdUsuario == usuarioId);

    if (anotacaoExistente != null)
    {
      // Atualizar a anotação existente
      anotacaoExistente.TextoAnotacao = annotation;
      _context.Anotacoes.Update(anotacaoExistente);
    }
    else
    {
      // Adicionar nova anotação
      var anotacao = new Anotacao
      {
        IdProjeto = projeto.IdProjeto,
        IdUsuario = usuarioId,
        TextoAnotacao = annotation,
      };
      _context.Anotacoes.Add(anotacao);
    }

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
      // Adicionar log para o erro de chave estrangeira
      ModelState.AddModelError("", "Erro ao salvar a anotação: " + ex.InnerException?.Message);
      return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
    }

    return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
  }

  // GET: Projetos/ResultadosBusca
  public async Task<IActionResult> ResultadosBusca(string searchTerm, string[] categorias, string palavrasChave, int? ano, int? periodo, int? rating)
  {
    var query = _context.Projetos.AsQueryable();

    if (!string.IsNullOrWhiteSpace(searchTerm))
    {
      query = query.Where(p => p.NomeProjeto.ToLower().Contains(searchTerm.ToLower()) ||
                               p.DescricaoProjeto.ToLower().Contains(searchTerm.ToLower()) ||
                               p.PalavraChave.ToLower().Contains(searchTerm.ToLower()) ||
                               p.UrlRepositorio.ToLower().Contains(searchTerm.ToLower()));
    }

    if (categorias != null && categorias.Length > 0)
    {
      var categoriasEnum = categorias.Select(c => (CategoriaEnum)Enum.Parse(typeof(CategoriaEnum), c)).ToList();
      query = query.Where(p => categoriasEnum.Contains(p.Categoria));
    }

    if (!string.IsNullOrWhiteSpace(palavrasChave))
    {
      query = query.Where(p => p.PalavraChave.ToLower().Contains(palavrasChave.ToLower()));
    }

    if (ano.HasValue)
    {
      query = query.Where(p => p.Ano == ano.ToString());
    }

    if (periodo.HasValue)
    {
      query = query.Where(p => p.Periodo == periodo.ToString());
    }

    if (rating.HasValue)
    {
      query = query.Where(p => p.NotaMedia >= rating);
    }

    var projetos = await query.ToListAsync();

    return View(projetos);
  }

  // GET: Projetos/BuscarProjeto
  public async Task<IActionResult> BuscarProjeto(string searchTerm)
  {
    if (string.IsNullOrWhiteSpace(searchTerm))
    {
      ModelState.AddModelError("", "Por favor, insira um termo de busca.");
      return View("ResultadosBusca", new List<Projeto>());
    }

    var projetos = await _context.Projetos
        .Where(p => p.NomeProjeto.ToLower().Contains(searchTerm.ToLower()) ||
                    p.DescricaoProjeto.ToLower().Contains(searchTerm.ToLower()) ||
                    p.PalavraChave.ToLower().Contains(searchTerm.ToLower()) ||
                    p.UrlRepositorio.ToLower().Contains(searchTerm.ToLower()))
        .ToListAsync();

    if (projetos.Any())
    {
      return View("ResultadosBusca", projetos);
    }
    else
    {
      ModelState.AddModelError("", "Nenhum projeto encontrado para o termo informado.");
      return View("ResultadosBusca", new List<Projeto>());
    }
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> VerificarRepositorio(string repoUrl)
  {
    if (string.IsNullOrWhiteSpace(repoUrl))
    {
      ModelState.AddModelError("", "Por favor, insira a URL do repositório.");
      return RedirectToAction(nameof(ResultadosBusca));
    }

    var projetoExistente = await _context.Projetos.FirstOrDefaultAsync(p => p.UrlRepositorio == repoUrl);
    if (projetoExistente != null)
    {
      ModelState.AddModelError("", "O projeto já está cadastrado.");
      return RedirectToAction(nameof(ResultadosBusca));
    }

    var repoInfo = ParseGitHubUrl(repoUrl);
    if (repoInfo.HasValue)
    {
      var (Owner, Repo) = repoInfo.Value;

      var readmeContent = await _gitHubService.GetFileContent(Owner, Repo, new[] { "README.md" });
      if (readmeContent != null)
      {
        var decodedReadme = _gitHubService.IsBase64String(readmeContent)
            ? GitHubService.DecodeBase64Content(readmeContent)
            : readmeContent;
        var (name, integrantes, ano, periodo) = GitHubService.ExtractDataFromReadme(decodedReadme);
        var introducao = "";

        string[] paths = new[] { "docs/01-Documentação de Contexto.md", "documentos/01-Documentação de Contexto.md" };
        var fileContent = await _gitHubService.GetFileContent(Owner, Repo, paths);
        if (fileContent != null)
        {
          introducao = _gitHubService.ExtractIntroduction(fileContent);
        }

        var novoProjeto = new Projeto
        {
          NomeProjeto = name,
          Ano = ano ?? DateTime.Now.Year.ToString(),
          Periodo = periodo ?? "1",
          Categoria = CategoriaEnum.Outros,
          PalavraChave = "",
          UrlRepositorio = repoUrl,
          DescricaoProjeto = introducao,
          Integrantes = integrantes,
        };

        return View("Criar", novoProjeto);
      }
      else
      {
        ModelState.AddModelError("", "Não foi possível encontrar o README no GitHub.");
        return RedirectToAction(nameof(ResultadosBusca));
      }
    }
    else
    {
      ModelState.AddModelError("", "URL do repositório inválida.");
      return RedirectToAction(nameof(ResultadosBusca));
    }
  }

  private (string Owner, string Repo)? ParseGitHubUrl(string url)
  {
    var match = Regex.Match(url, @"https:\/\/github\.com\/(?<owner>[^\/]+)\/(?<repo>[^\/]+)");
    if (match.Success)
    {
      return (match.Groups["owner"].Value, match.Groups["repo"].Value);
    }
    return null;
  }

}
