using AppInventario.Core.Interfaces;
using AppInventario.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInventario.InfraStructure.Repositories
{
    public class ClienteRepository : BaseRepository<Clientes>, IClienteRepository
    {
        public ClienteRepository(INVENTARIOContext context) : base(context) { }
        public async Task<IEnumerable<Clientes>> GetClientesById(int ClienteId)
        {
            return await _entitties.Where(x => x.Id == ClienteId).ToListAsync();
        }

        //public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        //{
        //    return await _entitties.Where(x => x.UserId == userId).ToListAsync();
        //}
    }
}
