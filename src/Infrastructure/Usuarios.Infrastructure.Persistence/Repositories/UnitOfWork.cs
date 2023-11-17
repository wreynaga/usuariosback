using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Application.Interface.Persistence;
using Usuarios.Infrastructure.Persistence.Contexts;

namespace Usuarios.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsersRepository Users { get; }
        public IUsuarioRepository Usuarios { get; }
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(IUsersRepository users, IUsuarioRepository usuarios, ApplicationDbContext applicationDbContext)
        {
            Users = users;
            Usuarios = usuarios;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
