using Usuarios.Application.DTO;
using Usuarios.Transversal.Common;

namespace Usuarios.Application.Interface.UseCases
{
    public interface IUsersApplication
    {
        Response<UserDto> Authenticate(string username, string password);
    }
}
