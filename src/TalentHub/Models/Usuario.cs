using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalentHub.Models
{
  public class Usuario
  {
    [Key]
    public int IdUsuario { get; set; }
    public string NomeUsuario { get; set; }
    public string Email { get; set; }
    public List<Projeto> Projetos { get; set; }
    public List<Avaliacao> Avaliacoes { get; set; }
    public List<Anotacao> Anotacoes { get; set; }
  }

}


