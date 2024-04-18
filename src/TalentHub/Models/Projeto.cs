using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalentHub.Models
{

  public class Projeto
  {
    [Key]
    public int IdProjeto { get; set; }
    public string NomeProjeto { get; set; }
    public string UrlRepositorio { get; set; }
    public string UrlAplicacao { get; set; }
    public string Integrantes { get; set; }
    public int QtdVisualizacoes { get; set; }
    public float NotaMedia { get; set; }
    public List<Avaliacao> Avaliacoes { get; set; }
    public List<Anotacao> Anotacoes { get; set; }
  }
}