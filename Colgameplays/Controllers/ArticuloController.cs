using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Colgameplays.Contracto;
using Colgameplays.Dtos.Articulo;
using Colgameplays.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colgameplays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "superadmin , admin")]
    public class ArticuloController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IArticuloRepositorio _articuloRepositorio;

        public ArticuloController(IArticuloRepositorio articuloRepositorio , IMapper mapper)
        {
            _mapper = mapper;
            _articuloRepositorio = articuloRepositorio;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<GetArticulosDto>>> All()
        {
            try { 
            var data = await _articuloRepositorio.All();

            if (data == null) return NotFound();

            return _mapper.Map<List<GetArticulosDto>>(data);

            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("search/{search}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<GetArticulosDto>>> Search(string search)
        {
            try
            {
                var data = await _articuloRepositorio.Search(search);

                if (data == null) return NotFound();

                return _mapper.Map<List<GetArticulosDto>>(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("one/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetArticulosDto>> One( int id)
        {
            try
            {

            var data = await _articuloRepositorio.One(id);

            if (data == null) return NotFound();

            return _mapper.Map<GetArticulosDto>(data);

            }catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ArticuloDto>> Add(ArticuloDto articuloDto)
        {
            try { 

            var articulo = _mapper.Map<Articulo>(articuloDto);

            var newArticulo = await _articuloRepositorio.Add(articulo);

            if (articulo == null) return BadRequest();

            var newArticuloDto = _mapper.Map<ArticuloDto>(articulo);

            return CreatedAtAction(nameof(Add), new { id = newArticuloDto.Id }, newArticuloDto);

            }catch(Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut("put/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ArticuloDto>> Put(int id, [FromBody] ArticuloDto articuloDto)
        {
            try
            {
                if (articuloDto == null) return NotFound();

                var articulo = _mapper.Map<Articulo>(articuloDto);

                var data = await _articuloRepositorio.Put(id, articulo);

                if (!data) return BadRequest();

                return _mapper.Map<ArticuloDto>(articuloDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Articulo>> Delete(int id)
        {
            try
            {
                var data = await _articuloRepositorio.Delete(id);

                if (!data) return BadRequest($"No se pudo eliminar el articulo con el id {id}.");

                return Ok("Se ha eliminado con exito.");

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
