using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Colgameplays.Contracto;
using Colgameplays.Dtos.Orden;
using Colgameplays.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colgameplays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrdenesRepositorio _ordenesRepositorio;

        public OrdenController(IOrdenesRepositorio ordenesRepositorio , IMapper mapper)
        {
            _mapper = mapper;
            _ordenesRepositorio = ordenesRepositorio;
        }


        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<GetOrdenDtos>>> All()
        {
            var data = await _ordenesRepositorio.All();

            if (data == null) return NotFound();

            return _mapper.Map<List<GetOrdenDtos>>(data);
        }

        [HttpGet("search/{search}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GetOrdenDtos>>> Search(string search)
        {
            var data = await _ordenesRepositorio.Search(search);

            if (data == null) return NotFound();

            return _mapper.Map<List<GetOrdenDtos>>(data);
        }

        [HttpGet("one/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetOrdenDtos>> One(int id)
        {
            var data = await _ordenesRepositorio.One(id);

            if (data == null) return NotFound();

            return _mapper.Map<GetOrdenDtos>(data);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrdenDto>> Add (OrdenDto ordenDto)
        {
            try { 

            var orden = _mapper.Map<Orden>(ordenDto);

            var newOrden = await _ordenesRepositorio.Add(orden);

            if (newOrden == null) return BadRequest();

            var newOrdenDto = _mapper.Map<OrdenDto>(newOrden);

            return CreatedAtAction(nameof(Add), new { id = newOrdenDto.Id }, newOrdenDto);

            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetOrdenDtos>> Delete(int id)
        {
            var data = await _ordenesRepositorio.Delete(id);

            if (!data) return BadRequest("No se pudo eliminar esta orden.");

            return Ok("Se ha eliminado con exito.");
        }
    }
}
