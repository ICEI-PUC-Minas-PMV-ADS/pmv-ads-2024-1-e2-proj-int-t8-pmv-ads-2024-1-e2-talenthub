using Microsoft.EntityFrameworkCore;
using TalentHub.Models;

namespace TalentHub.Data
{
  public class TalentHubContext : DbContext
  {
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Projeto> Projetos { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Anotacao> Anotacoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TalentHubDB;Trusted_Connection=True;");
    }
  }
}
