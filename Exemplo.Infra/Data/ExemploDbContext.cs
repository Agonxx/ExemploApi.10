using Exemplo.Domain.Entities;
using Exemplo.Infra.Data.ContextConfig;
using Microsoft.EntityFrameworkCore;

namespace Exemplo.Infra.Data;

public class ExemploDbContext : DbContext
{
    public ExemploDbContext(DbContextOptions<ExemploDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfigUsuario());
        modelBuilder.ApplyConfiguration(new ConfigTarefa());
    }
}
