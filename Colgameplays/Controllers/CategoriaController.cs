using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Colgameplays.Contracto;
using Colgameplays.Dtos.Categoria;
using Colgameplays.Enumerations;
using Colgameplays.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colgameplays.Controllers
{
    [Authorize( Roles = "superadmin , admin" )]
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio , IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<CategoriaDto>>> All()
        {
            var datos = await _categoriaRepositorio.All();

            if (datos == null || datos.Count == 0) return NotFound("No se ha encontrado categoria");

            return _mapper.Map<List<CategoriaDto>>(datos);
        }

        [HttpGet("search/{search}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> Search(string search)
        {
            var datos = await _categoriaRepositorio.Search(search);

            if (datos == null || datos.Count == 0) return NotFound($"No se ha encontrado categoria con el nombre: {search}");

            return _mapper.Map<List<CategoriaDto>>(datos);
        }


        [HttpGet("one/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaDto>> One(int id)
        {
            var data = await _categoriaRepositorio.One(id);

            if (data == null) return NotFound($"No se ha encontrado categoria con el id {id}");

            return _mapper.Map<CategoriaDto>(data);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Add (CategoriaDto categoriaDto)
        {
            try
            {
                var categoria =  _mapper.Map<Categoria>(categoriaDto);

                var newCategoria = await _categoriaRepositorio.Add(categoria);

                if (newCategoria == null) return BadRequest();

                var newCategoriaDto = _mapper.Map<CategoriaDto>(newCategoria);

                return CreatedAtAction(nameof(Add), new { id = newCategoriaDto.Id } , newCategoriaDto);

            }catch(Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut("put/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Put (int id , [FromBody] CategoriaDto categoriaDto)
        {

            try { 
        
            if (categoriaDto == null) return NotFound();

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            var data = await _categoriaRepositorio.Put(id , categoria);

            if (!data) return BadRequest();

            return _mapper.Map<CategoriaDto>(categoriaDto);


            }catch(Exception ex)
            {
                return BadRequest(ex);
            }



        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Delete(int id)
        {
            try
            {
                var data = await _categoriaRepositorio.Delete(id);

                if (!data) return BadRequest("No se pudo eliminar esta categoria.");

                return Ok("Se ha eliminado con exito.");

            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
