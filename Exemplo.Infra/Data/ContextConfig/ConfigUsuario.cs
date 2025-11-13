using Exemplo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exemplo.Infra.Data.ContextConfig
{
    public class ConfigUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(new[]
             {
                new Usuario {
                    Id = 1,
                    Nome="Rafael Santos",
                    Email="rafhita1@gmail.com",
                    Ativo = true,
                    SenhaHash = "AQAAAAEA",
                    CriadoEm= DateTime.Now,
                    AtualizadoEm =DateTime.Now,
                }
            });
        }
    }
}
