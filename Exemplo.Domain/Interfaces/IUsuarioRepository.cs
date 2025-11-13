using Exemplo.Domain.Entities;

namespace Exemplo.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> Create(Usuario usuarioObj);
    }
}
