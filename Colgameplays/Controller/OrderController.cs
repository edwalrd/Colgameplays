using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.OrderDtos;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepositor;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepositor = orderRepository;
            _mapper = mapper;
        }

        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<OrderDtos>>> All()
        {
            try
            {
                var data = await _orderRepositor.All();

                if (data == null || data.Count < 1) return NotFound("There are no registered orders.");

                return _mapper.Map<List<OrderDtos>>(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("One/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<OrderDtos>> One(int id)
        {
            try
            {
                var data = await _orderRepositor.One(id);

                if (data == null) return NotFound("There are no registered orders.");

                return _mapper.Map<OrderDtos>(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Add(AddOrderDtos addOrderDtos)
        {
            try
            {
                var data = _mapper.Map<Order>(addOrderDtos);

                data.IdUser = Convert.ToInt32(User.Claims.First(x => x.Type == "UserID").Value);


                var NewOrder = await _orderRepositor.Add(data);

                if (NewOrder == null) return BadRequest("Could not create a new Order.");

                return Ok("A new Order has been created.");
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

        public async Task<ActionResult> Update(int id, UpdateOrderDtos updateOrder)
        {
            try
            {
                var exit = await _orderRepositor.One(id);

                if (exit == null) return NotFound($"No Order found with this id {id}.");

                var Order = _mapper.Map<Order>(updateOrder);

                var data = await _orderRepositor.Update(id, Order);

                if (data == false) return BadRequest("This Order could not be updated.");

                return Ok("This Order has been updated.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateOrderDetails/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> UpdateOrderDetails(int id, UpdateOrderDetailDtos update)
        {
            try
            {
                var exit = await _orderRepositor.One(id);

                if (exit == null) return NotFound($"No Order found with this id {id}.");

                var OrderDetail = _mapper.Map<OrderDetail>(update);

                var data = await _orderRepositor.UpdateOrderDetails(id, OrderDetail);

                if (data == false) return BadRequest("This OrderDetail could not be updated.");

                return Ok("This OrderDetail has been updated.");
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
            var exit = await _orderRepositor.One(id);

            if (exit == null) return NotFound($"No Order found with this id {id}.");

            var data = await _orderRepositor.Delete(id);

            if (data == false) return BadRequest("This Order could not be cleared.");

            return Ok("This Order has been removed.");
        }

    }
}

