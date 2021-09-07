using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       [HttpGet]
       public ActionResult <IEnumerable<Command>> GetAllCommands()
       {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
       }

       [HttpGet("{id}")]
       public ActionResult <CommandReadDto> GetCommandById(int id)
       {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
       }

       //[HttpPost] 
       //public ActionResult <> AddCommand()
       //{

       //}

       //[HttpDelete()]
  
    }
}