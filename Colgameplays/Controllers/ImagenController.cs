using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Colgameplays.Contracto;
using Colgameplays.Dtos.Imagen;
using Colgameplays.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colgameplays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "superadmin , admin")]
    public class ImagenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IimagenRepositorio _fotoRepositorio;

        public ImagenController(IimagenRepositorio fotoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _fotoRepositorio = fotoRepositorio;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<GetAddImagenDto>>> Add([FromForm]  ImagenDto imagenDto)
        {
                try {

                    var data = new List<GetAddImagenDto>();

                foreach (var fotos in imagenDto.Foto)
                    {

                    var imagen = _mapper.Map<Imagen>(imagenDto);

                        if (imagenDto.Foto != null)

                        {
                            imagen.Foto = await _fotoRepositorio.Upload(fotos);
                        }

                        var newImagen = await _fotoRepositorio.Add(imagen);

                        if (newImagen == null) return BadRequest();

                        var newImagenDto = _mapper.Map<GetAddImagenDto>(newImagen);

                        data.Add(newImagenDto);

                        CreatedAtAction(nameof(Add), new { id = newImagenDto.Id }, newImagenDto);
                    }

                return _mapper.Map<List<GetAddImagenDto>>(data);

                }

                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
        }


        [HttpPut("put/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> Put(int id, [FromForm]  IFormFile archivo)
        {
            try
            {
                    if(archivo.Length == 0) return BadRequest();
            

                var data = await _fotoRepositorio.UpdateImagen(id, archivo);

                if (!data) return BadRequest();

                return Ok("Se ha actualizado con exito");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }



        }


        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetAddImagenDto>> Delete(int id)
        {
            try
            {
                var data = await _fotoRepositorio.Delete(id);

                if (!data) return BadRequest("No se pudo eliminar esta Imagen.");

                return Ok("Se ha eliminado con exito.");

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



    }

}
