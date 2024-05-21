using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class GitHubService
{
  private readonly HttpClient _httpClient;

  public GitHubService(HttpClient httpClient)
  {
    _httpClient = httpClient;
    _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
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
    var startIndex = content.IndexOf("# Introdução");
    var endIndex = content.IndexOf("## Problema");

    if (startIndex != -1 && endIndex != -1)
    {
      startIndex += "# Introdução".Length;
      return content.Substring(startIndex, endIndex - startIndex).Trim();
    }
    return string.Empty;
  }

  public static string DecodeBase64Content(string base64Content)
  {
    var decodedBytes = Convert.FromBase64String(base64Content);
    return Encoding.UTF8.GetString(decodedBytes);
  }

  public async Task<GitHubRepositoryData> GetRepositoryData(string owner, string repo)
  {
    var url = $"https://api.github.com/repos/{owner}/{repo}";
    var response = await _httpClient.GetAsync(url);

    if (!response.IsSuccessStatusCode)
    {
      return null;
    }

    var content = await response.Content.ReadAsStringAsync();
    var repoData = JsonConvert.DeserializeObject<GitHubRepositoryData>(content);
    return repoData;
  }

  public async Task<List<GitHubContributor>> GetRepositoryContributors(string owner, string repo)
  {
    var url = $"https://api.github.com/repos/{owner}/{repo}/contributors";
    var response = await _httpClient.GetAsync(url);

    if (!response.IsSuccessStatusCode)
    {
      return null;
    }

    var content = await response.Content.ReadAsStringAsync();
    var contributors = JsonConvert.DeserializeObject<List<GitHubContributor>>(content);

    var humanContributors = contributors.Where(c => !c.Login.Contains("[bot]")).ToList();
    return humanContributors;
  }

  public static (string Name, string Integrantes, string Ano, string Periodo) ExtractDataFromReadme(string readmeContent)
  {
    var name = ExtractProjectName(readmeContent);
    var integrantes = ExtractIntegrantes(readmeContent);
    var (ano, periodo) = ExtractAnoPeriodo(readmeContent);

    return (name, integrantes, ano, periodo);
  }

  private static string ExtractProjectName(string content)
  {
    var lines = content.Split('\n');
    return lines.Length > 0 ? lines[0].Replace("# ", "").Trim() : string.Empty;
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

  public bool IsBase64String(string base64)
  {
    Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
    return Convert.TryFromBase64String(base64, buffer, out _);
  }
}


public class GitHubFile
{
  public string Name { get; set; }
  public string Path { get; set; }
  public string Sha { get; set; }
  public int Size { get; set; }
  public string Url { get; set; }
  public string HtmlUrl { get; set; }
  public string GitUrl { get; set; }
  public string DownloadUrl { get; set; }
  public string Type { get; set; }
  public string Content { get; set; }
  public string Encoding { get; set; }
}

public class GitHubRepositoryData
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string HtmlUrl { get; set; }
  public string CloneUrl { get; set; }
  public string Language { get; set; }
  public int StargazersCount { get; set; }
  public int ForksCount { get; set; }
  public Owner Owner { get; set; }
}

public class Owner
{
  public string Login { get; set; }
  public string AvatarUrl { get; set; }
  public string HtmlUrl { get; set; }
}

public class GitHubContributor
{
  public string Login { get; set; }
  public int Id { get; set; }
  public string AvatarUrl { get; set; }
  public string HtmlUrl { get; set; }
  public int Contributions { get; set; }
}
