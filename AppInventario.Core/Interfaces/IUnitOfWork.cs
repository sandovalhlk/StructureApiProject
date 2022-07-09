using System;
using System.Threading.Tasks;

namespace AppInventario.Core.Interfaces
{
    public interface  IUnitOfWork : IDisposable
    {
        IClienteRepository ClienteRepository { get; }

        //IRepository<Productos> ProductoRepository { get; }

        void SaveChanges();

        Task SaveChangesAsyn();
    }
}
