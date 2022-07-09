using AppInventario.Core.Interfaces;
using AppInventario.InfraStructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppInventario.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        //private readonly IMapper _mapper;
        //public PostController(IPostService postService, IMapper mapper)
             public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
            //_mapper = mapper;
        }

        /// <summary>
        /// Devuelve el listado de clientes 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteService.GetClientes();
            //var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            //var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);
            var response = clientes;
            return Ok(response);
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPost(int id)
        //{

        //    var post = await _postService.GetPost(id);
        //    return Ok(post);
        //}

        //public async Task<IActionResult> Post(PostDto postDto)
        //{
        //    var post = _mapper.Map<Post>(postDto);
        //    await _postService.InsertPost(post);
        //    postDto = _mapper.Map<PostDto>(post);

        //    var response = new ApiResponse<PostDto>(postDto);
        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put(int id, PostDto postDto)
        //{
        //    var post = _mapper.Map<Post>(postDto);
        //    post.Id = id;
        //    var result = await _postService.UpdatePost(post);
        //    var response = new ApiResponse<bool>(result);
        //    return Ok(response);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{

        //    var result = await _postService.DeletePost(id);
        //    return Ok(result);
        //}
    }
}
