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
using Colgameplays.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Colgameplays.Enumerations;

namespace Colgameplays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "superadmin, admin")]
    public class ConsolasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConsolaRepositorio _IconsolaRepositorio;

        public ConsolasController(IConsolaRepositorio iconsola , IMapper mapper)
        {
            _mapper = mapper;
            _IconsolaRepositorio = iconsola;
        }

        // GET: api/Consolas
        [HttpGet("allconsola")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ConsolasDtos>>> GetConsolas()
        {
         var consolas =  await _IconsolaRepositorio.GetallConsolaAsyn();

            try
            {
                if (consolas == null)
                {
                    return NotFound("No hay consolas para mostrar");
                }

                return _mapper.Map<List<ConsolasDtos>>(consolas);

            }catch(Exception ex)
            {
                return BadRequest();
            }

           
        }

        [HttpGet("searchconsola/{search?}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ConsolasDtos>>> SearchConsolas(string? seaech)
        {
            try
            {
                if (string.IsNullOrEmpty(seaech))
                {
                    return await this.GetConsolas();
                }

                var consolas = await _IconsolaRepositorio.searchConsolaAsyn(seaech);

                if (consolas == null)
                {
                    return NotFound("No hay consolas para mostrar");
                }

                return _mapper.Map<List<ConsolasDtos>>(consolas);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }

        // GET: api/Consolas/5
        [HttpGet("getoneconsola/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConsolasDtos>> GetoneConsola(int id)
        {
            var consola = await _IconsolaRepositorio.GetoneConsola(id);

            if (consola == null)
            {
                return NotFound();
            }

            return _mapper.Map<ConsolasDtos>(consola); ;
        }
      
      // POST: api/Consolas
      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      [HttpPost("Addconsola")]
      [ProducesResponseType(StatusCodes.Status201Created)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<ActionResult<AddConsolaDtos>> PostConsola(AddConsolaDtos consolaDtos)
      {
            try
            {
                var consola = _mapper.Map<Consola>(consolaDtos);

                var new_consola = await _IconsolaRepositorio.AddConsola(consola);

                if (new_consola == null) return BadRequest();

                var new_consolaDto = _mapper.Map<AddConsolaDtos>(new_consola);

                return CreatedAtAction(nameof(PostConsola), new { id = new_consolaDto.Id }, new_consolaDto);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            
       
      }
      
    // DELETE: api/Consolas/5
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Consola>> DeleteConsola(int id)
        {
            try
            {
                var resultado = await _IconsolaRepositorio.DeleteConsola(id);

                if (!resultado)
                {
                    return BadRequest("No se pudo eliminar este juego!!");
                }

                return NoContent();
            }
            catch (Exception excepcion)
            {
                return BadRequest();
            }



        }

        [HttpPut("putconsola/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConsolasPutDto>> PutConsola(int id, [FromBody] ConsolasPutDto consolaDto)
        {
            try
            {
                if (consolaDto == null)
                {
                    return NotFound();
                }

                var consola = _mapper.Map<Consola>(consolaDto);

                var data = await _IconsolaRepositorio.PutConsola(id, consola);

                if (!data)
                {
                    return BadRequest();
                }

                return _mapper.Map<ConsolasPutDto>(consolaDto);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        
        }

    }
}
