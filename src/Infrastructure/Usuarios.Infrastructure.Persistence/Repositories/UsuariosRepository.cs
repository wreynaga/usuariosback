using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Application.Interface.Persistence;
using Usuarios.Domain.Entities;
using Usuarios.Infrastructure.Persistence.Contexts;

namespace Usuarios.Infrastructure.Persistence.Repositories
{
    public class UsuariosRepository : IUsuarioRepository
    {
        protected readonly ApplicationDbContext _applicationDbContext;


        public UsuariosRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public int Count()
        {
            throw new NotImplementedException();
        }
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public bool Insert(Usuario entity)
        {
            throw new NotImplementedException();
        }
        public bool Update(Usuario entity)
        {
            throw new NotImplementedException();
        }





        public async Task<bool> InsertAsync(Usuario entity)
        {
            _applicationDbContext.Add(entity);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Usuario entity)
        {
            var entity_new = await _applicationDbContext.Set<Usuario>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(entity.Id));
            if (entity_new == null)
            {
                return await Task.FromResult(false);
            }
            entity_new.Nombre = entity.Nombre;
            entity_new.Edad = entity.Edad;
            entity_new.Correo = entity.Correo;

            _applicationDbContext.Update(entity);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _applicationDbContext.Set<Usuario>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(int.Parse(id)));

            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _applicationDbContext.Remove(entity);
            return await Task.FromResult(true);
        }

        public async Task<List<Usuario>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Set<Usuario>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Usuario> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.
                Set<Usuario>().AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public Task<IEnumerable<Usuario>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
