using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.AddressDtos;
using Colgameplays.Model.Entities;
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
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IUserRepository userRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpGet("One/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AddressDto>> One(int id)
        {
            var data = await _addressRepository.One(id);

            if (data == null) return NotFound("This Addrres not found.");

            return _mapper.Map<AddressDto>(data);
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(AddressDto AddressDto)
        {
            try
            {
                var IdUser = Convert.ToInt32(User.Claims.First(x => x.Type == "UserID").Value);

                var address = _mapper.Map<Address>(AddressDto);

                address.IdUser = IdUser;

                var newAddress = await _addressRepository.Add(address);

                if (newAddress == null) return BadRequest("Could not save this address.");

                return Ok("This address has been created.");

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

        public async Task<ActionResult> Update(int id, AddressDto addressDto)
        {
            var exist = await _addressRepository.One(id);

            if (exist == null) return NotFound("This address has not been found.");

            var data = _mapper.Map<Address>(addressDto);

            var address = await _addressRepository.Update(id, data);

            if (address == false) return BadRequest("An error occurred while modifying this address.");

            return Ok("This address has been modified.");
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                var exist = await _addressRepository.One(id);

                if (exist == null) return NotFound("This address has not been found.");

                var data = await _addressRepository.Delete(id);

                if (data == false) return BadRequest("This address could not be removed.");

                return Ok("This address has been removed.");

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
