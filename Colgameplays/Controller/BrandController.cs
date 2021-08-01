using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.BrandDtos;
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
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandController(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        [HttpGet("All")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BrandDtos>>> All()
        {
            var data = await _brandRepository.GetallAsyn();

            if (data == null) return NotFound("there are no trademarks.");

            return _mapper.Map<List<BrandDtos>>(data);
        }

        [HttpGet("One/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BrandDtos>> One(int id)
        {
            var data = await _brandRepository.GetOneAsyn(id);

            if (data == null) return NotFound("This brand not found.");

            return _mapper.Map<BrandDtos>(data);
        }

     

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Add(BrandDtos brandDtos)
        {
            try
            {
                var exit = await _brandRepository.GetallAsyn();

                foreach(var see in exit)
                {
                    if (see.Name == brandDtos.Name) return BadRequest("This brand already exists, Please enter a different one to this one.");
                }

                var brand = _mapper.Map<Brand>(brandDtos);

                var NewBrand = await _brandRepository.Add(brand);

                if (brand == null) return BadRequest("Could not create a new Brand.");

                return Ok("A new brand has been created.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Update(int id, BrandDtos dtos)
        {
            try
            {
                var exist = await this._brandRepository.GetOneAsyn(id);

                if (exist == null) return NotFound($"No Brand found with this id {id}.");


                if(exist.Name != dtos.Name)
                {
                    var sameName = await _brandRepository.GetallAsyn();

                    foreach (var see in sameName)
                    {
                        if (see.Name == dtos.Name) return BadRequest("This brand already exists, Please enter a different one to this one.");
                    }
                }
               

                var brand = _mapper.Map<Brand>(dtos);

                var data = await _brandRepository.Update(id, brand);

                if (!data) return BadRequest("This brand could not be updated.");

                return Ok("Changes made.");

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

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var exist = await this._brandRepository.GetOneAsyn(id);

                if (exist == null) return NotFound($"No Brand found with this id {id}.");


                var data = await _brandRepository.Delete(id);

                if (data == false) return BadRequest("This brand could not be removed.");

                return Ok("Brand removed.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
