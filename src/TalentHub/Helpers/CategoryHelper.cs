namespace TalentHub.Helpers
{
  public static class CategoryHelper
  {
    public static string GetIconForCategory(string categoria)
    {
      switch (categoria.ToLower())
      {
        case "saude":
          return "fas fa-heartbeat";
        case "tecnologia":
          return "fas fa-laptop-code";
        case "financas":
          return "fas fa-chart-line";
        case "projetossociais":
          return "fas fa-hands-helping";
        case "turismo":
          return "fas fa-plane";
        case "lazer":
          return "fas fa-football-ball";
        case "outros":
          return "fas fa-ellipsis-h";
        default:
          return "fas fa-folder";
      }
    }
  }
}
