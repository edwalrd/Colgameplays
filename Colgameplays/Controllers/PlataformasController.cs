using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Colgameplays.Context;
using Colgameplays.model;
using Colgameplays.Contracto;
using AutoMapper;
using Colgameplays.Dtos;
using Microsoft.AspNetCore.Authorization;
using Colgameplays.Enumerations;

namespace Colgameplays.Controllers
{
    [Authorize(Roles = "superadmin , admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IPlataformaRepositorio _Iplataforma;

        public PlataformasController(IPlataformaRepositorio Iplataforma , IMapper mapper )
        {
            _mapper = mapper;
            _Iplataforma = Iplataforma;
        }

        // GET: api/Plataformas
        [HttpGet("allplataforma")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PlataformaDtos>>> GetPlataformas()
        {
            try
            {
                var plataforma = await _Iplataforma.GetPlataformaAsyn();

                if (plataforma == null || plataforma.Count == 0) return NotFound("No se ha encontrado plataforma");
              
                return _mapper.Map<List<PlataformaDtos>>(plataforma);

            }catch(Exception ex)
            {
                return BadRequest();
            }
             
        }

        [HttpGet("Searchplataforma/{search?}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PlataformaDtos>>> SearchPlataformaAsyn(string? search)
        {
            try
            {

                if (string.IsNullOrEmpty(search))
                {
                return  await  this.GetPlataformas();
                }
         
            var datos = await _Iplataforma.SearchPlataformaAsyn(search);

            if (datos == null || datos.Count == 0) return NotFound("No se ha encontrado Plataforma con esta palabra");


            return  _mapper.Map<List<PlataformaDtos>>(datos);

            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Plataformas/5
        [HttpGet("getoneplataforma/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PlataformaDtos>> GetonePlataforma(int id)
        {
            try
            {

            var plataforma = await  _Iplataforma.GetOnePlataformaAsyn(id);

            if (plataforma == null)
            {
                    return NotFound("No se ha encontrado esta plataforma");
             }

            return _mapper.Map<PlataformaDtos>(plataforma);


            }catch(Exception ex)
            {
                return BadRequest() ;
            }

        }

        // POST: api/Plataformas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("addplataforma")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PlataformaDtos>> PostPlataforma(PlataformaDtos plataformaDto)
        {
            try
            {
                var plataforma = _mapper.Map<Plataforma>(plataformaDto);

                var nuevaplataforma = await _Iplataforma.AddPlataforma(plataforma);

                if (nuevaplataforma == null)
                {
                    return BadRequest();
                }

                var nuevaplataformaDto = _mapper.Map<PlataformaDtos>(nuevaplataforma); 

                return CreatedAtAction(nameof(PostPlataforma), new {id = nuevaplataformaDto.Id }, nuevaplataformaDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut("putplataforma/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PlataformaDtos>> PutPlataforma (int id , [FromBody] PlataformaDtos plataformaDto)
        {
            if (plataformaDto == null)
            {
                return NotFound();
            }

            var plataforma = _mapper.Map<Plataforma>(plataformaDto);

            var resultado = await _Iplataforma.PutPlataforma(id ,plataforma);

            if (!resultado)
            {
                return BadRequest();
            }

            return _mapper.Map<PlataformaDtos>(plataformaDto);

        }

        // DELETE: api/Plataformas/5
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Plataforma>> DeletePlataforma(int id)
        {
            try
            {
                var resultado = await _Iplataforma.DeletePlataformas(id);

                if (!resultado)
                {
                    return BadRequest("No se pudo eliminar esta plataforma!!");
                }
                return NoContent();
            }
            catch (Exception excepcion)
            {
                return BadRequest();
            }
        }


    }
}
