using Exemplo.Domain.Entities;
using Exemplo.Domain.Interfaces;

namespace Exemplo.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CriarAsync(Usuario usuarioObj)
        {
            await _repo.Create(usuarioObj);
            return true;
        }
    }
}
