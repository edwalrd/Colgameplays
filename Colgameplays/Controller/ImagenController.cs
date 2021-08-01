using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.ImagenDtos;
using Colgameplays.Entities;
using Colgameplays.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImagenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IimagesRepository _imagesRepository;
        private const string conteiner = "Article";
        private List<string> Extensions = new List<String> { ".jpg", ".jpe", ".png" };


        public ImagenController(IMapper mapper, IimagesRepository imagesRepository)
        {
            _mapper = mapper;
            _imagesRepository = imagesRepository;
        }


        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Add([FromForm] imageDtos data)
        {
            try
            {
                var count = new List<GetImagenDto>();

                foreach (var x in data.Image)
                {
                    var image = _mapper.Map<Image>(data);

                    var ext = x.FileName.Split(".")[1];

                    if (!Extensions.Contains(Path.GetExtension($".{ext}").ToLowerInvariant()))
                    {
                        return BadRequest("Only .JPG, .JPE, .PNG images are allowed");
                    }

                    image.Name = await _imagesRepository.Upload(x, conteiner);

                    var newImagen = await _imagesRepository.Add(image);

                    if (newImagen == null) return BadRequest($"An error occurred while adding the image {newImagen.Id}");

                    var newImagenDtos = _mapper.Map<GetImagenDto>(newImagen);

                    count.Add(newImagenDtos);

                }

                return Ok($"{count.Count} image has been added.");
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

        public async Task<ActionResult> Update(int id, [FromForm] UpdateImageDtos dtos)
        {
            try
            {
                var exit = await _imagesRepository.One(id);

                if (exit == null) return BadRequest("This image was not found.");

                var ext = dtos.Image.FileName.Split(".")[1];

                if (!Extensions.Contains(Path.GetExtension($".{ext}").ToLowerInvariant()))
                {
                    return BadRequest("Only .JPG, .JPE, .PNG images are allowed");
                }

                var data = await _imagesRepository.UpdateImagen(id, dtos, conteiner);

                if (data == false) return BadRequest("This image could not be modified.");

                return Ok("Modified image.");
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

        [HttpGet("One/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetImagenDto>> All(int id)
        {
            try
            {
                var data = await _imagesRepository.One(id);

                if (data == null) return NotFound($"No category found with this id: {id}.");

                return _mapper.Map<GetImagenDto>(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }

    }
}
