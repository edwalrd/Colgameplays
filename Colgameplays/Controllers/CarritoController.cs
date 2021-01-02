using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Colgameplays.Contracto;
using Colgameplays.Dtos.Carrito;
using Colgameplays.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colgameplays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarritoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICarritoRepositorio _carritoRepositorio;

        public CarritoController(ICarritoRepositorio carritoRepositorio , IMapper imapper)
        {
            _mapper = imapper;
            _carritoRepositorio = carritoRepositorio;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<GetCarriotDto>>> All()
        {
            try { 

            var data = await _carritoRepositorio.All();

            if (data == null) return NotFound("No tiene articulo en el carrito de comprar");

            return _mapper.Map<List<GetCarriotDto>>(data);

            }catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("search/{search}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<GetCarriotDto>>> Search(string search)
        {
            try
            {
                var data = await _carritoRepositorio.Search(search);
            
                if (data == null) return NotFound($"No se ha encontrado articulo con la palabra {search}");

                return _mapper.Map<List<GetCarriotDto>>(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("one/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<GetCarriotDto>> One(int id)
        {
            var data = await _carritoRepositorio.One(id);

            if (data == null) return NotFound($"No se ha encontrado resultado con el id {id}");

            return _mapper.Map<GetCarriotDto>(data);

        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarritoDto>> Add(CarritoDto carritoDto)
        {

            try { 

            var carrito = _mapper.Map<Carrito>(carritoDto);

            var newCarrito = await _carritoRepositorio.Add(carrito);

            if (newCarrito == null) return BadRequest();

            var newCarritoDto = _mapper.Map<CarritoDto>(newCarrito);

            return CreatedAtAction(nameof(Add), new { id = newCarritoDto.Id }, newCarritoDto);

            }catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Carrito>> Delete(int id)
        {

            try { 

            var data = await _carritoRepositorio.Delete(id);

            if (!data) return BadRequest("No se pudo eliminar esta categoria.");

            return Ok("Se ha eliminado con exito.");
            
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
