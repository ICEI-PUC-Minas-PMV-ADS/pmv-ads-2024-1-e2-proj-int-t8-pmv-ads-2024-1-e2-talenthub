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
    public required string NomeProjeto { get; set; }

    [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
    public required string DescricaoProjeto { get; set; }

    [Required(ErrorMessage = "O campo Ano é obrigatório.")]
    public required string Ano { get; set; }

    [Required(ErrorMessage = "O campo Período é obrigatório.")]
    public required string Periodo { get; set; }

    [Required(ErrorMessage = "O campo Categoria do Repositório é obrigatório.")]
    public CategoriaEnum Categoria { get; set; }

    [Required(ErrorMessage = "O campo Palavra-chave é obrigatório.")]
    public required string PalavraChave { get; set; }

    [Required(ErrorMessage = "O campo URL do Repositório é obrigatório.")]
    public required string UrlRepositorio { get; set; }

    public string? UrlAplicacao { get; set; }

    [Required(ErrorMessage = "O campo Integrantes é obrigatório.")]
    public required string Integrantes { get; set; }

    public string? InformacoesContato { get; set; }

    public int QtdVisualizacoes { get; set; }

    public float NotaMedia { get; set; }
      
    public int UsuarioIdUsuario { get; set; }

    public List<Anotacao> Anotacoes { get; set; } = new List<Anotacao>();
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

    [Required]
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public bool Deletado { get; set; } = false;
  }
}