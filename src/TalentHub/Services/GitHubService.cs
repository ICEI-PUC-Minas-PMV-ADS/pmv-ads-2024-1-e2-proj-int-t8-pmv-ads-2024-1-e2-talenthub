using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

  public async Task<string> GetFileContent(string owner, string repo, string path)
  {
    var url = $"https://api.github.com/repos/{owner}/{repo}/contents/{path}";
    var response = await _httpClient.GetAsync(url);

    if (!response.IsSuccessStatusCode)
    {
      return null;
    }

    var content = await response.Content.ReadAsStringAsync();
    var fileData = JsonConvert.DeserializeObject<GitHubFile>(content);

    if (fileData?.Content != null)
    {
      var fileContent = Encoding.UTF8.GetString(Convert.FromBase64String(fileData.Content));
      return fileContent;
    }

    return null;
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
