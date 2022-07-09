using AppInventario.Core.Interfaces;
using AppInventario.InfraStructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppInventario.Core.Services
{
    public  class ClientesService : IClienteService
    {
        //esto sera sustituido por unit of work
        //private readonly IRepository<Post> _postRepository;
        //private readonly IRepository<User> _userRepository;


        //IEnumerable<Clientes> GetClientes();
        //Task<Clientes> GetCliente(int id);

        //Task InsertCliente(Clientes post);

        //Task<bool> UpdateCliente(Clientes post);

        //Task<bool> DeleteCliente(int id);

        private readonly IUnitOfWork _unitOfWork;

        public ClientesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        
        public async Task<Clientes> GetCliente(int id)
        {

            return await _unitOfWork.ClienteRepository.GetById(id);
        }

       
        public IEnumerable<Clientes> GetClientes()
        {
            return _unitOfWork.ClienteRepository.GetAll();
        }



        public async Task InsertCliente(Clientes cliente)
        {
            //var cliente = await _unitOfWork.ClientesRepository.GetById(cliente.ClienteId);
            //if (user == null)
            //{
            //    throw new Exception("User dosen't exist");
            //}

            //var userPost = await _unitOfWork.PostRepository.GetClientesById(cliente.ClienteId);
            //if (userPost.Count() < 10)
            //{
            //    var lasPost = userPost.LastOrDefault();
            //    if ((lasPost.Date - DateTime.Now).TotalDays < 7)
            //    {
            //        throw new BusinessException("You are not able to publish the post");
            //    }
            //}

            //if (post.Description.Contains("sexo"))
            //{
            //    throw new BusinessException("Content not allowed");
            //}

            await _unitOfWork.ClienteRepository.Add(cliente);

        }
        public async Task<bool> UpdateCliente(Clientes cliente)
        {
            _unitOfWork.ClienteRepository.Update(cliente);
            await _unitOfWork.SaveChangesAsyn();
            return true;

        }

        public async Task<bool> DeleteCliente(int id)
        {
            await _unitOfWork.ClienteRepository.Delete(id);
            return true;
        }
    }
}
