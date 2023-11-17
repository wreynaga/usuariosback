using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Application.Interface.Persistence;

namespace Usuarios.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsersRepository Users { get; }

        public UnitOfWork(IUsersRepository users)
        {
            Users = users;
        }
        //public async Task<int> Save(CancellationToken cancellationToken)
        //{
        //    //return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        //}
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
