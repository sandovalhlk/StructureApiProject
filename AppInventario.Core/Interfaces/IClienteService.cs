using AppInventario.InfraStructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppInventario.Core.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<Clientes> GetClientes();
        Task<Clientes> GetCliente(int id);

        Task InsertCliente(Clientes post);

        Task<bool> UpdateCliente(Clientes post);

        Task<bool> DeleteCliente(int id);
    }
}
