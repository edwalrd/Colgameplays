using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.Cart_Item;
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
    public class Cart_ItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICart_ItemRepository _cart_ItemRepository;
        private readonly IUserRepository _userRepository;

        public Cart_ItemController(ICart_ItemRepository cart_ItemRepository , IUserRepository userRepository , IMapper mapper)
        {
            _mapper = mapper;
            _cart_ItemRepository = cart_ItemRepository;
            _userRepository = userRepository;
        }

        [HttpGet("One/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cart_ItemDtos>> One(int id)
        {
            try
            {
               var data =  await _cart_ItemRepository.One(id);

                if (data == null) return NotFound($"No Cart Item found with this id: {id}.");

                return _mapper.Map<Cart_ItemDtos>(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SearchByDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Cart_ItemDtos>>> SearchByDate( )
        {
            try
            {
                string Ddate = "2021/07/17";

                 string Hdate = "2021/07/17";

                var data = await _cart_ItemRepository.SearchByDate(Ddate , Hdate);

                if (data == null) return NotFound($"No Cart Item found.");

                return _mapper.Map<List<Cart_ItemDtos>>(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Add(AddCart_ItemDtos cart_ItemDtos)
        {
            try
            {
                var idUser = Convert.ToInt32(User.Claims.First(x => x.Type == "UserID").Value);

                var ShoppingSessionUser = await _userRepository.GetOneAsyn(idUser);

                cart_ItemDtos.IdShoppingSeccion = ShoppingSessionUser.Id;

                var CreateCart_items = _mapper.Map<Cart_Item>(cart_ItemDtos);

                var data = await _cart_ItemRepository.Add(CreateCart_items);

                if (data == null) return BadRequest("Could not create a new Cart_Item.");

                return Ok("A new Cart_Item has been created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult>Delete(int id)
        {
            try
            {
                var IdUser = Convert.ToInt32(User.Claims.First(x => x.Type == "UserID").Value);

                var shoppin = await _userRepository.OneShoppingSeccion(IdUser);

                var exit = await One(id);

                if (exit.Value == null) return NotFound($"No Cart Item found with this id {id}.");

                if (shoppin.Id != exit.Value.IdShoppingSeccion)
                {
                    return BadRequest("Este Cart Item no le pertenece a este User");
                }
                
                var data = await _cart_ItemRepository.Delete(id);

                if (data == false) return BadRequest("This Cart Item could not be cleared.");

                return Ok("This Cart Item has been removed.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
