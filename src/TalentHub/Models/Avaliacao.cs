using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalentHub.Models
{
  public class Avaliacao
  {
    [Key]
    public int IdAvaliacao { get; set; }

    public int IdUsuario { get; set; }

    public Usuario Usuario { get; set; }

    public int IdProjeto { get; set; }

    public Projeto Projeto { get; set; }

    public int Nota { get; set; }

    public string Comentario { get; set; }

    public DateTime DataAvaliacao { get; set; } = DateTime.Now;
  }
}