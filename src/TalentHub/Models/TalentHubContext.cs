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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Projeto>()
          .Property(p => p.DataCriacao)
          .HasDefaultValueSql("GETDATE()");

      modelBuilder.Entity<Anotacao>()
          .HasOne(a => a.Projeto)
          .WithMany(p => p.Anotacoes)
          .HasForeignKey(a => a.IdProjeto)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Anotacao>()
          .HasOne(a => a.Usuario)
          .WithMany(u => u.Anotacoes)
          .HasForeignKey(a => a.IdUsuario)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Avaliacao>()
          .HasOne(a => a.Projeto)
          .WithMany(p => p.Avaliacoes)
          .HasForeignKey(a => a.IdProjeto)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Avaliacao>()
          .HasOne(a => a.Usuario)
          .WithMany(u => u.Avaliacoes)
          .HasForeignKey(a => a.IdUsuario)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
