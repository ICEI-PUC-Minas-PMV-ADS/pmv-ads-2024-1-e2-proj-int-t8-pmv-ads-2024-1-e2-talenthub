using System;
using TalentHub.Helpers;

namespace TalentHub.Helpers
{
  public static class CategoriaHelper
  {
    public static string GetIconForCategoria(CategoriaEnum categoria)
    {
      switch (categoria)
      {
        case CategoriaEnum.Saude:
          return "fas fa-heartbeat";
        case CategoriaEnum.Tecnologia:
          return "fas fa-laptop-code";
        case CategoriaEnum.Financas:
          return "fas fa-chart-line";
        case CategoriaEnum.ProjetosSociais:
          return "fas fa-hands-helping";
        case CategoriaEnum.Turismo:
          return "fas fa-plane";
        case CategoriaEnum.Lazer:
          return "fas fa-football-ball";
        case CategoriaEnum.Educacao:
          return "fas fa-graduation-cap";
        case CategoriaEnum.Esporte:
          return "fas fa-dumbbell";
        case CategoriaEnum.Ciencia:
          return "fas fa-flask";
        case CategoriaEnum.MeioAmbiente:
          return "fas fa-leaf";
        case CategoriaEnum.Comercio:
          return "fas fa-shopping-cart";
        case CategoriaEnum.Outros:
          return "fa-solid fa-globe";
        default:
          return "fas fa-folder";
      }
    }
  }
}
