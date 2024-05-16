using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

public class GitHubService
{
  private readonly HttpClient _httpClient;

  public GitHubService(HttpClient httpClient)
  {
    _httpClient = httpClient;
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
