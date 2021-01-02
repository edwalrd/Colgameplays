using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Colgameplays.Contracto;
using Colgameplays.Dtos;
using Colgameplays.Dtos.Usuario;
using Colgameplays.Enumerations;
using Colgameplays.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colgameplays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "superadmin , admin")]
    public class UsuarioController : ControllerBase
    {
        private readonly IAuthRepositorio _IAuthRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPasswordRepositorio _passwordService;
        private readonly IMapper _mapper;

        public UsuarioController(IAuthRepositorio IAuthRepositorio, IUsuarioRepositorio usuarioRepositorio ,  IPasswordRepositorio passwordService  ,  IMapper mapper)
        {
            _IAuthRepositorio = IAuthRepositorio;
            _passwordService = passwordService;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GetUsuarioDto>>> AllUsers()
        {
            try { 

            var datos = await _usuarioRepositorio.AllusersAsync();

            if (datos == null || datos.Count == 0) return NotFound("No se ha encontrado usuarios");

            return _mapper.Map<List<GetUsuarioDto>>(datos);
            
            }catch(Exception ex)
            {
                return BadRequest();
            }


        }

        [HttpGet("search/{search}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GetUsuarioDto>>> SearchUsers(string search)
        {
            try
            {

                var datos = await _usuarioRepositorio.SearchUsersAsync(search);

                if (datos == null || datos.Count == 0) return NotFound("No se ha encontrado usuarios");

                return _mapper.Map<List<GetUsuarioDto>>(datos);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }


        [HttpGet("one/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetUsuarioDto>> OnehUsers(int id)
        {
            try
            {
                var datos = await _usuarioRepositorio.OneUserAsync(id);

                if (datos == null ) return NotFound("No se ha encontrado Usuario con este id");

                return _mapper.Map<GetUsuarioDto>(datos);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }

        [HttpPost("Guardar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDtos>> Guardar(UsuarioDtos usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);

                var exitUser = await _IAuthRepositorio.LoginUser(usuario.User);

                if (exitUser != null) return BadRequest("Este Usuario ya existe, Por favor introducir otro.");

                usuario.Password = _passwordService.Hash(usuario.Password);

                var newUsuario = await _IAuthRepositorio.RegistrarUser(usuario);

                if(newUsuario == null)
                {
                    return BadRequest();
                }

                var newUsuarioDto = _mapper.Map<UsuarioDtos>(newUsuario);

                return CreatedAtAction(nameof(Guardar), new { id = newUsuarioDto.Id }, newUsuarioDto);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }


        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDtos>> Delete (int id)
        {
            try { 

                var data = await _usuarioRepositorio.Delete(id);

                if (!data)  return BadRequest("No se pudo eliminar este Usuario !!!");

                return Ok("Se ha eliminado con exito");

            }
                catch (Exception excepcion)
               {
                    return BadRequest();
               }
        }

        [HttpPut("changerole/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<roleDto>> ChangeRoleUser(int id , [FromBody] roleDto role)
        {

            try { 

            var data = await _usuarioRepositorio.ChangeRoleUser(id, role);

            if (!data ) return BadRequest();

            return Ok("Se ha cambiado el rol de este usuario");
            
            }

            catch (Exception excepcion)
            {
                return BadRequest();
            }

        }
    }
}
