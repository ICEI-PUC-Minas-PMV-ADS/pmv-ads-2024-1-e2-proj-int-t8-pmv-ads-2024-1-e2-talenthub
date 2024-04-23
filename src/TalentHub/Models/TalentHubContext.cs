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

    public TalentHubContext(DbContextOptions<TalentHubContext> options)
           : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        IConfiguration config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        var connectionString = config["CONNECTION_STRING"];
        optionsBuilder.UseSqlServer(connectionString);
      }
    }
  }
}
