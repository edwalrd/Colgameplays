using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Colgameplays.Contracto;
using Colgameplays.Dtos.Domicilio;
using Colgameplays.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colgameplays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DomicilioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDomicilioRepositorio _domicilioRepositorio;

        public DomicilioController(IMapper mapper , IDomicilioRepositorio domicilioRepositorio)
        {
            _mapper = mapper;
            _domicilioRepositorio = domicilioRepositorio;
        }

        [HttpGet("one/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DomicilioDto>> One(int id)
        {
            var data = await _domicilioRepositorio.One(id);

            if (data == null) return NotFound($"No se ha encontrado el domicilio con el id {id}");

            return _mapper.Map<DomicilioDto>(data);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DomicilioDto>> Add(DomicilioDto domicilioDto)
        {
            try { 
            
            var domicilio = _mapper.Map<Domicilio>(domicilioDto);

            var newDomicilio = await _domicilioRepositorio.Add(domicilio);

            if (newDomicilio == null) return BadRequest();

            var newdomicilioDto = _mapper.Map<DomicilioDto>(newDomicilio);

            return CreatedAtAction(nameof(Add), new { id = newdomicilioDto.Id }, newdomicilioDto);

            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("put/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DomicilioDto>> Put(int id , DomicilioDto domicilioDto)

        {
            try { 

                if (domicilioDto == null) return NotFound();

                var domicilio = _mapper.Map<Domicilio>(domicilioDto);

                var data = await _domicilioRepositorio.Put(id, domicilio);

                if (!data) return BadRequest();

                return _mapper.Map<DomicilioDto>(domicilioDto);

             }

            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Domicilio>> Delete (int id)
        {
            try
            {
                var data = await _domicilioRepositorio.Delete(id);

                if (!data) return BadRequest();

                return Ok("Este Domicilio ha sido borrado");

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
