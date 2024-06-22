using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;
using Newtonsoft.Json;

public class AzureLanguageService
{
  private readonly HttpClient _httpClient;
  private readonly string _endpoint;

  public AzureLanguageService(HttpClient httpClient, IConfiguration configuration)
  {
    _httpClient = httpClient;
    _endpoint = configuration["AzureLanguageService:Endpoint"];
  }

  public async Task<List<string>> ExtractKeyPhrasesAsync(string text, int maxKeyPhrases = 15)
  {
    const int maxLength = 5120;
    if (text.Length > maxLength)
    {
      text = text.Substring(0, maxLength);
    }

    var requestContent = new
    {
      documents = new[]
        {
            new { language = "pt", id = "1", text }
        }
    };

    var response = await _httpClient.PostAsync($"{_endpoint}/text/analytics/v3.1/keyPhrases",
        new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json"));

    response.EnsureSuccessStatusCode();

    var responseString = await response.Content.ReadAsStringAsync();
    var jsonResponse = JObject.Parse(responseString);

    var keyPhrases = jsonResponse["documents"][0]["keyPhrases"].ToObject<List<string>>();

    return keyPhrases.Take(maxKeyPhrases).ToList();
  }


  public List<string> ExtractNames(string content)
  {
    var names = new List<string>();

    var doc = new HtmlDocument();
    doc.LoadHtml(content);

    var subNodes = doc.DocumentNode.SelectNodes("//sub");

    if (subNodes != null)
    {
      foreach (var node in subNodes)
      {
        names.Add(node.InnerText.Trim());
      }
    }
    else
    {
      void ExtractTextNodes(HtmlNode node)
      {
        if (node.NodeType == HtmlNodeType.Text && !string.IsNullOrWhiteSpace(node.InnerText))
        {
          var text = node.InnerText.Trim();
          if (!string.IsNullOrWhiteSpace(text) && !text.Contains(","))
          {
            names.Add(text);
          }
        }
        foreach (var child in node.ChildNodes)
        {
          ExtractTextNodes(child);
        }
      }

      ExtractTextNodes(doc.DocumentNode);
    }

    if (!names.Any())
    {
      names.AddRange(content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(n => n.Trim())
                            .Where(n => !string.IsNullOrWhiteSpace(n) && !n.Contains(",")));
    }

    return names.Where(name => !string.IsNullOrWhiteSpace(name)).Distinct().ToList();
  }

  public async Task<CategoriaEnum> SugerirCategoriaAsync(string text)
  {
    var keyPhrases = await ExtractKeyPhrasesAsync(text, 200);
    var categorias = Enum.GetValues(typeof(CategoriaEnum)).Cast<CategoriaEnum>().ToList();

    foreach (var phrase in keyPhrases)
    {
      foreach (var categoria in categorias)
      {
        if (phrase.Contains(categoria.GetDescription(), StringComparison.OrdinalIgnoreCase))
        {
          return categoria;
        }
      }
    }

    return CategoriaEnum.Outros;
  }

}
