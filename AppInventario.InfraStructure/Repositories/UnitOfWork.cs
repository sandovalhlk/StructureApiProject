using AppInventario.Core.Interfaces;
using AppInventario.InfraStructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppInventario.InfraStructure.Repositories
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly INVENTARIOContext _context;
        private readonly IClienteRepository _clienteRepository;
        //private readonly IRepository<User> _userRepository;
        //private readonly IRepository<Comment> _commentRepository;
        
        public UnitOfWork(INVENTARIOContext context)
        {
            _context = context;
        }

        public IClienteRepository ClienteRepository => _clienteRepository ?? new ClienteRepository(_context);

        //public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);

        //public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsyn()
        {
            await _context.SaveChangesAsync();
        }
    }
}
