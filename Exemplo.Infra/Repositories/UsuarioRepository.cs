using Exemplo.Domain.Entities;
using Exemplo.Domain.Interfaces;
using Exemplo.Infra.Data;

namespace Exemplo.Infra.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        public readonly ExemploDbContext _db;

        public UsuarioRepository(ExemploDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Usuario usuarioObj)
        {
            _db.Usuarios.Add(usuarioObj);
            _db.SaveChanges();

            return true;
        }
    }
}
