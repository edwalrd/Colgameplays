using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.ArticleDtos;
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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleController(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;

        }

        [HttpGet("All")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<AllArticleDtos>>> All()
        {
            try
            {
                var data = await _articleRepository.GetallAsyn();

                if (data == null || data.Count < 1) return NotFound("There are no categories registered.");

                return _mapper.Map<List<AllArticleDtos>>(data);

            }
            catch (Exception ex)
            {
             return BadRequest(ex.Message);
            }


        }

        [HttpGet("Search/{search}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<AllArticleDtos>>> Search(string search)
        {
            try
            {
                var data = await _articleRepository.SearchAsyn(search);

                if (data == null || data.Count < 1) return NotFound($"No results found for your search ({search}).");

                return _mapper.Map<List<AllArticleDtos>>(data);

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

        public async Task<ActionResult<AllArticleDtos>> One(int id)
        {
            try
            {
                var data = await _articleRepository.GetOneAsyn(id);

                if (data == null ) return NotFound($"No order found with this id: {id}.");

                return _mapper.Map<AllArticleDtos>(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(CreateArticleDtos createArticleDtos)
        {
            try
            {
                var article = _mapper.Map<Article>(createArticleDtos);

                var newArticle = await _articleRepository.Add(article);

                if (newArticle == null) return BadRequest("Could not create a new Article.");

                return Ok("A new Article has been created.");

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

        public async Task<ActionResult> Update(int id , CreateArticleDtos createArticleDtos)
        {
            try
            {
                var exit = await _articleRepository.GetOneAsyn(id);

                if (exit == null) return NotFound($"No Article found with this id {id}.");

                var article = _mapper.Map<Article>(createArticleDtos);

                var data = await _articleRepository.Update(id, article);

                if (data == false) return BadRequest("This Article could not be updated.");

                return Ok("This Article has been updated.");
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
                var exit = await _articleRepository.GetOneAsyn(id);

                if (exit == null) return NotFound($"No Article found with this id {id}.");

                var data = await _articleRepository.Delete(id);

                if (data == false) return BadRequest("This Article could not be cleared.");

                return Ok("This Article has been removed.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}
