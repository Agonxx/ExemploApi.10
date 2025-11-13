using Exemplo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exemplo.Infra.Data.ContextConfig
{
    public class ConfigTarefa : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasOne<Usuario>()
               .WithMany()
               .HasForeignKey(h => h.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
