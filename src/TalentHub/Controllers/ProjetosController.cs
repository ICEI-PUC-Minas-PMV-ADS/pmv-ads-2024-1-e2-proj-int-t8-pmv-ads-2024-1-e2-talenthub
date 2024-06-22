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
  private readonly AzureLanguageService _azureLanguageService;

  public ProjetosController(TalentHubContext context, GitHubService gitHubService, AzureLanguageService azureLanguageService)
  {
    _context = context;
    _gitHubService = gitHubService;
    _azureLanguageService = azureLanguageService;
  }

  // GET: Projetos
  public async Task<IActionResult> Index()
  {
    var projetos = await _context.Projetos.ToListAsync();
    return View(projetos);
  }

  // GET: Projetos/Gerenciar
  public async Task<IActionResult> Gerenciar(int? pageNumber)
  {

    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    var projetos = _context.Projetos
               .Where(a => a.UsuarioIdUsuario == usuarioId)
               .Where(a => a.Deletado == false)
               .AsNoTracking();

    int pageSize = 10;
    return View(await PaginatedList<Projeto>.CreateAsync(projetos, pageNumber ?? 1, pageSize));
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
                  .Include(p => p.Avaliacoes)
                    .ThenInclude(a => a.Usuario)
                  .AsSplitQuery()
                  .FirstOrDefaultAsync(m => m.IdProjeto == id);

    if (projeto == null)
    {
      return NotFound();
    }

    if (projeto.Avaliacoes.Any())
    {
      projeto.NotaMedia = (float)projeto.Avaliacoes.Average(a => a.Nota);
    }
    else
    {
      projeto.NotaMedia = 0;
    }

    if (User != null && User.Identity.IsAuthenticated)
    {
      var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);
      var anotacao = projeto.Anotacoes.FirstOrDefault(a => a.IdUsuario == usuarioId);

      ViewBag.AnnotacaoExistente = anotacao;
    }

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
    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    return View();
  }

  // POST: Projetos/Criar
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Criar([Bind("NomeProjeto,UrlRepositorio,UrlAplicacao,Integrantes,Ano,Periodo,PalavraChave,DescricaoProjeto,Categoria,InformacoesContato,UsuarioIdUsuario")] Projeto projeto)
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
      return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
    }
    catch (Exception ex)
    {
      TempData["ErrorMessage"] = "Não foi possível salvar os dados";
      ModelState.AddModelError("", "Não foi possível salvar os dados. Detalhes do erro: " + ex.Message);
    }

    return View(projeto);
  }


  // GET: Projetos/Editar/5
  public async Task<IActionResult> Editar(int? id)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    if (id == null)
    {
      TempData["ErrorMessage"] = "ID do projeto não informado.";
      return NotFound();
    }

    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto == null)
    {
      TempData["ErrorMessage"] = "Projeto não encontrado.";
      return NotFound();
    }

    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);
    if (projeto.UsuarioIdUsuario != usuarioId)
    {
      TempData["ErrorMessage"] = "Você não tem permissão para editar este projeto.";
      return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
    }

    return View(projeto);
  }

  // POST: Projetos/Edit/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Editar(int id, [Bind("IdProjeto,NomeProjeto,DescricaoProjeto,Ano,Periodo,Categoria,PalavraChave,UrlRepositorio,UrlAplicacao,Integrantes,InformacoesContato,UsuarioIdUsuario")] Projeto projeto)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    if (id != projeto.IdProjeto)
    {
      TempData["ErrorMessage"] = "O ID do projeto não corresponde ao projeto enviado.";
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

      TempData["SuccessMessage"] = "Projeto atualizado com sucesso!";
      return View(projeto);
    }
    return View(projeto);
  }

  // GET: Projetos/Apagar/5
  public async Task<IActionResult> Apagar(int? id)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    if (id == null)
    {
      TempData["ErrorMessage"] = "ID do projeto não informado.";
      return NotFound();
    }

    var projeto = await _context.Projetos.FirstOrDefaultAsync(m => m.IdProjeto == id);
    if (projeto == null)
    {
      TempData["ErrorMessage"] = "Projeto não encontrado.";
      return NotFound();
    }

    return View(projeto);
  }

  // POST: Projetos/Apagar/5
  [HttpPost]
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
      projeto.Deletado = true;
      _context.Projetos.Update(projeto);
      await _context.SaveChangesAsync();
      TempData["SuccessMessage"] = "Projeto removido com sucesso!";
    }
    return RedirectToAction(nameof(Gerenciar));
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> AvaliarProjeto(int id, int rating, string comments)
  {
    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);

    var projeto = await _context.Projetos
                                .Include(p => p.Avaliacoes)
                                .FirstOrDefaultAsync(p => p.IdProjeto == id);
    if (projeto == null)
    {
      TempData["ErrorMessage"] = "Projeto não encontrado.";
      return NotFound();
    }

    var avaliacaoExistente = projeto.Avaliacoes.FirstOrDefault(a => a.IdUsuario == usuarioId);
    if (avaliacaoExistente != null)
    {
      avaliacaoExistente.Nota = rating;
      avaliacaoExistente.Comentario = comments;
      avaliacaoExistente.DataAvaliacao = DateTime.Now;
    }
    else
    {
      var novaAvaliacao = new Avaliacao
      {
        IdProjeto = id,
        IdUsuario = usuarioId,
        Nota = rating,
        Comentario = comments,
        DataAvaliacao = DateTime.Now,
      };
      projeto.Avaliacoes.Add(novaAvaliacao);
    }

    if (projeto.Avaliacoes.Any())
    {
      projeto.NotaMedia = (float)projeto.Avaliacoes.Average(a => a.Nota);
    }
    else
    {
      projeto.NotaMedia = 0;
    }

    try
    {
      await _context.SaveChangesAsync();
      TempData["SuccessMessage"] = "Avaliação salva com sucesso!";
    }
    catch (DbUpdateException ex)
    {
      ModelState.AddModelError("", "Erro ao salvar a avaliação: " + ex.InnerException?.Message);
      TempData["ErrorMessage"] = "Erro ao salvar a avaliação.";
      return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
    }

    return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> SalvarAnotacao(int id, string annotation)
  {

    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    var usuarioId = int.Parse(User.FindFirst("IdUsuario").Value);

    var projeto = await _context.Projetos.FindAsync(id);
    if (projeto == null)
    {
      TempData["ErrorMessage"] = "Projeto não encontrado.";
      return NotFound();
    }

    var anotacaoExistente = await _context.Anotacoes
        .FirstOrDefaultAsync(a => a.IdProjeto == projeto.IdProjeto && a.IdUsuario == usuarioId);

    if (anotacaoExistente != null)
    {
      anotacaoExistente.TextoAnotacao = annotation;
      _context.Anotacoes.Update(anotacaoExistente);
    }
    else
    {
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
      TempData["SuccessMessage"] = "Anotação salva com sucesso!";
    }
    catch (DbUpdateException ex)
    {
      ModelState.AddModelError("", "Erro ao salvar a anotação: " + ex.InnerException?.Message);
      TempData["ErrorMessage"] = "Erro ao salvar a anotação.";
      return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
    }

    return RedirectToAction(nameof(Detalhes), new { id = projeto.IdProjeto });
  }

  // GET: Projetos/ResultadosBusca
  public async Task<IActionResult> ResultadosBusca(string searchTerm, string[]? categorias, string? palavrasChave, string? autor, int? ano, int? periodo, int? rating, int? pageNumber)
  {
    var query = _context.Projetos.AsQueryable();

    if (!string.IsNullOrWhiteSpace(searchTerm))
    {
      query = query.Where(p => p.NomeProjeto.ToLower().Contains(searchTerm.ToLower()) ||
                               p.DescricaoProjeto.ToLower().Contains(searchTerm.ToLower()) ||
                               p.PalavraChave.ToLower().Contains(searchTerm.ToLower()) ||
                               p.UrlRepositorio.ToLower().Contains(searchTerm.ToLower()))
                               .Where(a => a.Deletado == false);
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

    if (!string.IsNullOrWhiteSpace(autor))
    {
      query = query.Where(p => p.Integrantes.ToLower().Contains(autor.ToLower()));
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

    int pageSize = 10;
    var projetos = await PaginatedList<Projeto>.CreateAsync(query.AsNoTracking(), pageNumber ?? 1, pageSize);

    return View(projetos);
  }

  // GET: Projetos/BuscarProjeto
  public async Task<IActionResult> BuscarProjeto(string searchTerm, int? pageNumber)
  {
    if (string.IsNullOrWhiteSpace(searchTerm))
    {
      ModelState.AddModelError("", "Por favor, insira um termo de busca.");
      return View("ResultadosBusca", new PaginatedList<Projeto>(new List<Projeto>(), 0, 1, 10));
    }

    searchTerm = searchTerm.ToLower();
    var query = _context.Projetos.AsQueryable()
        .Where(p => p.NomeProjeto.ToLower().Contains(searchTerm) ||
                    p.DescricaoProjeto.ToLower().Contains(searchTerm) ||
                    p.PalavraChave.ToLower().Contains(searchTerm) ||
                    p.UrlRepositorio.ToLower().Contains(searchTerm))
                    .Where(a => a.Deletado == false);

    int pageSize = 10;
    var projetos = await PaginatedList<Projeto>.CreateAsync(query.AsNoTracking(), pageNumber ?? 1, pageSize);

    if (projetos.Any())
    {
      return View("ResultadosBusca", projetos);
    }
    else
    {
      ModelState.AddModelError("", "Nenhum projeto encontrado para o termo informado.");
      return View("ResultadosBusca", new PaginatedList<Projeto>(new List<Projeto>(), 0, 1, pageSize));
    }
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> VerificarRepositorio(string repoUrl)
  {
    if (!User.Identity.IsAuthenticated)
    {
      return RedirectToAction("Index", "Home");
    }

    if (string.IsNullOrWhiteSpace(repoUrl))
    {
      ModelState.AddModelError("", "Por favor, insira a URL do repositório.");
      TempData["ErrorMessage"] = "Por favor, insira a URL do repositório.";
      return RedirectToAction(nameof(ResultadosBusca));
    }

    var projetoExistente = await _context.Projetos.FirstOrDefaultAsync(p => p.UrlRepositorio == repoUrl);
    if (projetoExistente != null)
    {
      TempData["ErrorMessage"] = "O projeto já está cadastrado.";
      ModelState.AddModelError("", "O projeto já está cadastrado.");
      return RedirectToAction(nameof(ResultadosBusca));
    }

    var repoInfo = ParseGitHubUrl(repoUrl);
    if (repoInfo.HasValue)
    {
      var (Owner, Repo) = repoInfo.Value;

      var readmeContent = await _gitHubService.GetFileContent(Owner, Repo, new[] { "README.md" });
      var name = string.Empty;
      var integrantes = string.Empty;
      var ano = string.Empty;
      var periodo = string.Empty;

      if (readmeContent != null)
      {
        var decodedReadme = _gitHubService.IsBase64String(readmeContent)
            ? GitHubService.DecodeBase64Content(readmeContent)
            : readmeContent;
        (name, integrantes, ano, periodo) = GitHubService.ExtractDataFromReadme(decodedReadme, repoUrl);
      }

      if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ano) || string.IsNullOrWhiteSpace(periodo))
      {
        var parsedData = GitHubService.ParseRepoUrlForDetails(repoUrl);
        name = string.IsNullOrWhiteSpace(name) ? parsedData.name : name;
        ano = string.IsNullOrWhiteSpace(ano) ? parsedData.ano : ano;
        periodo = string.IsNullOrWhiteSpace(periodo) ? parsedData.periodo : periodo;
      }

      var introducao = string.Empty;

      string[] paths = new[] { "docs/01-Documentação de Contexto.md", "documentos/01-Documentação de Contexto.md", "documents/01-Documentação de Contexto.md" };
      var fileContent = await _gitHubService.GetFileContent(Owner, Repo, paths);
      if (fileContent != null)
      {
        introducao = _gitHubService.ExtractIntroduction(fileContent);
      }

      if (!string.IsNullOrEmpty(introducao))
      {
        var keyPhrases = await _azureLanguageService.ExtractKeyPhrasesAsync(introducao, 15);
        var categoria = await _azureLanguageService.SugerirCategoriaAsync(introducao);
        var nomesIntegrantes = GetFormattedNames(integrantes);

        var novoProjeto = new Projeto
        {
          NomeProjeto = name,
          Ano = !string.IsNullOrEmpty(ano) ? ano : DateTime.Now.Year.ToString(),
          Periodo = !string.IsNullOrEmpty(periodo) ? periodo : "1",
          Categoria = categoria,
          PalavraChave = string.Join(", ", keyPhrases),
          UrlRepositorio = repoUrl,
          DescricaoProjeto = introducao,
          Integrantes = nomesIntegrantes,
        };

        return View("Criar", novoProjeto);
      }
      else
      {
        ModelState.AddModelError("", "Texto de introdução não encontrado.");
        TempData["ErrorMessage"] = "Texto de introdução não encontrado.";
        return RedirectToAction(nameof(ResultadosBusca));
      }
    }
    else
    {
      ModelState.AddModelError("", "URL do repositório inválida.");
      TempData["ErrorMessage"] = "URL do repositório inválida.";
      return RedirectToAction(nameof(ResultadosBusca));
    }
  }

  public string GetFormattedNames(string content)
  {
    var names = _azureLanguageService.ExtractNames(content);
    return string.Join(", ", names);
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

  private (string name, string ano, string periodo) ParseRepoUrlForDetails(string repoUrl)
  {
    var match = Regex.Match(repoUrl, @"pmv-(ads|sint)-(\d{4})-(\d)-e(\d)-.*-(\d+)-(.+)");
    if (match.Success)
    {
      var ano = match.Groups[2].Value;
      var periodo = match.Groups[3].Value + "-" + match.Groups[4].Value;
      var name = match.Groups[6].Value.Replace("-", " ");
      return (name, ano, periodo);
    }
    return (string.Empty, string.Empty, string.Empty);
  }
}
