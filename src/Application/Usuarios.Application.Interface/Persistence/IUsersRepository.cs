using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Application.Interface.Persistence
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        User Authenticate(string username, string password);

    }
}
