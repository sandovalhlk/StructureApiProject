using AppInventario.InfraStructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppInventario.Core.Interfaces
{

    public interface IClienteRepository : IRepository<Clientes>
    {
        Task<IEnumerable<Clientes>> GetClientesById(int id);
    }   
}
