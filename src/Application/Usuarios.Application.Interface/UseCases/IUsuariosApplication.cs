using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Application.DTO;
using Usuarios.Transversal.Common;

namespace Usuarios.Application.Interface.UseCases
{
    public interface IUsuariosApplication
    {
        Task<Response<bool>> Create(UsuarioDto discountDto, CancellationToken cancellationToken = default);
        Task<Response<bool>> Update(UsuarioDto discountDto, CancellationToken cancellationToken = default);
        Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default);
        Task<Response<UsuarioDto>> Get(int id, CancellationToken cancellationToken = default);
        Task<Response<List<UsuarioDto>>> GetAll(CancellationToken cancellationToken = default);

    }
}
