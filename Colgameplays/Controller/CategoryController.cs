using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.Category;
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
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepositry _categoryRepositry;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepositry categoryRepositry, IMapper mapper)
        {
            _categoryRepositry = categoryRepositry;
            _mapper = mapper;
        }

        [HttpGet("All")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<CategoryDtos>>> All()
        {
            try
            {
            var data = await _categoryRepositry.GetallAsyn();

            if (data == null || data.Count < 1) return NotFound("There are no categories registered.");

            return _mapper.Map<List<CategoryDtos>>(data);
            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("One/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CategoryDtos>> One(int id)
        {
            try
            {
                var data = await _categoryRepositry.GetOneAsyn(id);

                if (data == null) return NotFound($"No category found with this id: {id}.");

                return _mapper.Map<CategoryDtos>(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(CategoryDtos categoryDtos)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDtos);

                var data = await _categoryRepositry.Add(category);

                if (data == null) return BadRequest("This category could not be added.");

                return Ok($"the {data.Name} category has been created.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id,  CategoryDtos categoryDtos)
        {
            try
            {
                var exist = await this._categoryRepositry.GetOneAsyn(id);

                if (exist == null) return NotFound($"No Category found with this id {id}.");

                var category = _mapper.Map<Category>(categoryDtos);

                var data = await _categoryRepositry.Update(id, category);

                if (data == false) return BadRequest("This category could not be updated.");

                return Ok("This category has been updated.");
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
                var exist = await this._categoryRepositry.GetOneAsyn(id);

                if (exist == null) return NotFound($"No Category found with this id {id}.");

                var data = await _categoryRepositry.Delete(id);

            if (data == false) return BadRequest("This category could not be deleted ");

            return Ok("This category has been removed.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
