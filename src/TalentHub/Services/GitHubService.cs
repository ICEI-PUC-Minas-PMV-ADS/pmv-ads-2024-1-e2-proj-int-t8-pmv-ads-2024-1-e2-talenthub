using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

public class GitHubService
{
  private readonly HttpClient _httpClient;

  public GitHubService(HttpClient httpClient, string token)
  {
    _httpClient = httpClient;
    _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", token);
  }

  public async Task<string> GetFileContent(string owner, string repo, string[] paths)
  {
    foreach (var path in paths)
    {
      var url = $"https://api.github.com/repos/{owner}/{repo}/contents/{path}?ref=main";
      var response = await _httpClient.GetAsync(url);

      if (response.IsSuccessStatusCode)
      {
        var content = await response.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);
        if (json.RootElement.TryGetProperty("content", out var contentElement))
        {
          var base64Content = contentElement.GetString();
          if (!string.IsNullOrEmpty(base64Content) && IsBase64String(base64Content))
          {
            var decodedBytes = Convert.FromBase64String(base64Content);
            var decodedString = Encoding.UTF8.GetString(decodedBytes);
            return decodedString;
          }
          else
          {
            return base64Content;
          }
        }
      }
    }
    return null;
  }

  public string ExtractIntroduction(string content)
  {
    var startIndex = content.IndexOf("# ");
    if (startIndex == -1)
    {
      return string.Empty;
    }

    startIndex = content.IndexOf("\n", startIndex);
    if (startIndex == -1)
    {
      return string.Empty;
    }

    startIndex += "\n".Length;

    var endIndex = content.IndexOf("\n##", startIndex);
    if (endIndex == -1)
    {
      endIndex = content.IndexOf("\n#", startIndex);
    }
    if (endIndex == -1)
    {
      endIndex = content.Length;
    }

    return content.Substring(startIndex, endIndex - startIndex).Trim();
  }


  public static string DecodeBase64Content(string base64Content)
  {
    var decodedBytes = Convert.FromBase64String(base64Content);
    return Encoding.UTF8.GetString(decodedBytes);
  }

  public static (string Name, string Integrantes, string Ano, string Periodo) ExtractDataFromReadme(string readmeContent, string repoUrl)
  {
    var (nameFromUrl, anoFromUrl, periodoFromUrl) = ParseRepoUrlForDetails(repoUrl);

    var nameFromReadme = ExtractProjectName(readmeContent);
    var integrantes = ExtractIntegrantes(readmeContent);
    var (anoFromReadme, periodoFromReadme) = ExtractAnoPeriodo(readmeContent);

    var name = !string.IsNullOrEmpty(nameFromReadme) ? nameFromReadme : nameFromUrl;
    var ano = !string.IsNullOrEmpty(anoFromUrl) ? anoFromUrl : anoFromReadme;
    var periodo = !string.IsNullOrEmpty(periodoFromUrl) ? periodoFromUrl : periodoFromReadme;

    return (name, integrantes, ano, periodo);
  }

  private static string ExtractProjectName(string content)
  {
    var lines = content.Split('\n').Select(line => line.Trim()).ToList();

    foreach (var line in lines)
    {
      if (line.StartsWith("# "))
      {
        return line.Replace("# ", "").Trim();
      }
      else if (line.StartsWith("![") || line.StartsWith("<img"))
      {
        continue;
      }
    }

    return string.Empty;
  }

  private static string ExtractIntegrantes(string content)
  {
    var integrantesPattern = @"(?<=Integrantes\s*).+?((?=\s*Orientador)|$)";
    var match = Regex.Match(content, integrantesPattern, RegexOptions.Singleline);

    if (match.Success)
    {
      var integrantesList = match.Value
          .Split(new[] { '*', '#', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
          .Select(i => i.Trim())
          .Where(i => !string.IsNullOrEmpty(i))
          .ToList();
      return string.Join(", ", integrantesList);
    }
    return string.Empty;
  }

  private static (string Ano, string Periodo) ExtractAnoPeriodo(string content)
  {
    var anoPattern = @"\b[0-9]{4}\b";
    var periodoPattern = @"(?:\b(1|2|3|4)[ºº]?\s*(?:semestre|Semestre|SEMESTRE|Eixo|eixo|EIXO)\b)|(?:\b(?:semestre|Semestre|SEMESTRE|Eixo|eixo|EIXO)\s*(1|2|3|4)\b)";

    string ano = Regex.Match(content, anoPattern).Value;

    var periodoMatch = Regex.Match(content, periodoPattern, RegexOptions.IgnoreCase);
    string periodo = string.Empty;

    if (periodoMatch.Success)
    {
      periodo = periodoMatch.Groups[1].Success ? periodoMatch.Groups[1].Value : periodoMatch.Groups[2].Value;
    }

    return (ano, periodo);
  }

  public static (string name, string ano, string periodo) ParseRepoUrlForDetails(string repoUrl)
  {
    var match = Regex.Match(repoUrl, @"pmv-(ads|sint)-(\d{4})-(\d)-e(\d)-.*?-(.+)", RegexOptions.IgnoreCase);
    if (match.Success)
    {
      var ano = match.Groups[2].Value;
      var periodo = match.Groups[4].Value;
      var name = match.Groups[5].Value.Split('-').Last().Replace("-", " ");
      return (name, ano, periodo);
    }
    return (string.Empty, string.Empty, string.Empty);
  }


  public bool IsBase64String(string base64)
  {
    Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
    return Convert.TryFromBase64String(base64, buffer, out _);
  }
}
