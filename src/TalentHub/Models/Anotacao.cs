using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalentHub.Models
{
  public class Anotacao
  {
    [Key]
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public int IdProjeto { get; set; }
    public Projeto Projeto { get; set; }
    public string TextoAnotacao { get; set; }
  }
}