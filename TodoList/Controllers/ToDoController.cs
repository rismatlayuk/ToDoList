using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Domain.Models;
using TodoList.Domain.Services;
using TodoList.Resources;

namespace TodoList.Controllers
{
    [Route("api/todo")]
    [Produces("application/json")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public ToDoController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;   
        }


        /// <summary>
        /// Lists all ToDo.
        /// </summary>
        /// <returns>List of ToDo.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ToDoResource>), 200)]
        public async Task<IEnumerable<ToDoResource>> ListAsync()
        {
            var todos = await _todoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoResource>>(todos);

            return resources;
        }


        /// <summary>
        /// Deletes a given ToDO according to an identifier.
        /// </summary>
        /// <param name="id">ToDo identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ToDoResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _todoService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var todoResource = _mapper.Map<ToDo, ToDoResource>(result.Resource);
            return Ok(todoResource);
        }
    }
}