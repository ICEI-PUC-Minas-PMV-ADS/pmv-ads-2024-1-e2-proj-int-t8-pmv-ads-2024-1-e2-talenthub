using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalentHub.Models
{
  public class Projeto
  {
    [Key]
    public int IdProjeto { get; set; }

    [Required(ErrorMessage = "O campo Nome do Projeto é obrigatório.")]
    public string NomeProjeto { get; set; }
    
    // [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
    public string DescricaoProjeto { get; set; }
    
    // [Required(ErrorMessage = "O campo Ano é obrigatório.")]
    public string Ano { get; set; }
  
    // [Required(ErrorMessage = "O campo Período é obrigatório.")]
    public string Periodo { get; set; }
    
    // [Required(ErrorMessage = "O campo Categoria do Repositório é obrigatório.")]
    public CategoriaEnum Categoria { get; set; }
    
    public string PalavraChave { get; set; }

    [Required(ErrorMessage = "O campo URL do Repositório é obrigatório.")]
    public string UrlRepositorio { get; set; }

    [Required(ErrorMessage = "O campo URL da Aplicação é obrigatório.")]
    public string UrlAplicacao { get; set; }

    [Required(ErrorMessage = "O campo Integrantes é obrigatório.")]
    public string Integrantes { get; set; }
    public int QtdVisualizacoes { get; set; }
    public float NotaMedia { get; set; }
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    public List<Anotacao> Anotacoes { get; set; } = new List<Anotacao>();
  }
}