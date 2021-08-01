using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.Consoles;
using Colgameplays.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin , Admin")]
    public class ConsoleController : ControllerBase
    {
        private readonly IConsolesRepository _consolesRepository;
        private readonly ColgameplaysContext _context;
        private readonly IMapper _mapper;

        public ConsoleController(IConsolesRepository consolesRepository, ColgameplaysContext context, IMapper mapper)
        {
            _consolesRepository = consolesRepository;
            _context = context;
            _mapper = mapper;
            _mapper = mapper;
        }

        [HttpGet("All")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<ConsoleDtos>>> All()
        {
            var data = await _consolesRepository.GetallAsyn();

            if (data == null) return NotFound("There are no registered consoles.");

            return _mapper.Map<List<ConsoleDtos>>(data);
            
        }

        [HttpGet("Search/{search}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<ConsoleDtos>>> Search(string search)
        {
            var data = await _consolesRepository.SearchAsyn(search);

            if (data == null || data.Count < 1) return NotFound($"No results found for your search ({search}).");

            return _mapper.Map<List<ConsoleDtos>>(data);

        }

        [HttpGet("One/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ConsoleDtos>> One(int id)
        {
            var data = await _consolesRepository.GetOneAsyn(id);

            if (data == null) return NotFound("No console found with this id.");

            return _mapper.Map<ConsoleDtos>(data);

        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(ConsoleDtos consoleDtos)
        {
            try
            {
                var console = _mapper.Map<Consoles>(consoleDtos);

                var data = await _consolesRepository.Add(console);

                if (data == null) return BadRequest("could not save this console.");

                return Ok("Console saved successfully.");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ConsoleDtos>> Update(int id , ConsoleDtos consoleDtos)
        {
            try
            {
                var exist = await this._consolesRepository.GetOneAsyn(id);

                if (exist == null) return NotFound($"No Console found with this id {id}.");

                var console = _mapper.Map<Consoles>(consoleDtos);

                var data = await _consolesRepository.Update(id, console);

                if (data == false) return BadRequest("This console could not be updated.");

                return Ok("This console has been updated.");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ConsoleDtos>> Delete(int id)
        {
            try
            {
                var exist = await this._consolesRepository.GetOneAsyn(id);

                if (exist == null) return NotFound($"No Console found with this id {id}.");

                var data = await _consolesRepository.Delete(id);

            if (data == false) return BadRequest("This console could not be cleared.");

            return Ok("This console has been removed.");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
