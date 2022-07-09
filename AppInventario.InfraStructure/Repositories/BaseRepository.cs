using AppInventario.Core.Entities;
using AppInventario.Core.Interfaces;
using AppInventario.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppInventario.InfraStructure.Repositories
{
    public  class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly INVENTARIOContext _context;
        protected readonly DbSet<T> _entitties;
        public BaseRepository(INVENTARIOContext context)
        {
            _context = context;
            _entitties = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entitties.AsEnumerable();
        }
        public async Task<T> GetById(int id)
        {
            return await _entitties.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entitties.AddAsync(entity);

        }

        public void Update(T entity)
        {

            _entitties.Update(entity);

        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entitties.Remove(entity);

        }


    }
}
