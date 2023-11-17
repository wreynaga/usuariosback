using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Application.Interface.Persistence
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetAsync(int id, CancellationToken cancellationToken);
        Task<List<Usuario>> GetAllAsync(CancellationToken cancellationToken);
    }
}
