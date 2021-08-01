using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.User;
using Colgameplays.Dtos.UserDtos;
using Colgameplays.Entities;
using Colgameplays.Model.Option;
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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authTokenRepository;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IAuthRepository authTokenRepository, IMapper mapper, IPasswordRepository passwordRepository)
        {
            _userRepository = userRepository;
            _authTokenRepository = authTokenRepository;
            _passwordRepository = passwordRepository;
            _mapper = mapper;
        }

        [HttpGet("All/{role?}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<UserDto>>> All(string role)
        {
            try
            {
                if (string.IsNullOrEmpty(role))
                {
                    var data = await _userRepository.GetallAsyn();

                    if (data == null) return NotFound("No hay Usuario en este sistema");

                    return _mapper.Map<List<UserDto>>(data);
                }

                var datas = await _userRepository.GetallByRoleAsyn(role);

                if (datas == null) return NotFound("No hay Usuario en este sistema");

                return _mapper.Map<List<UserDto>>(datas);
            }

            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("Search/{search}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<UserDto>>> Search(string search)
        {
            try
            {
                var datas = await _userRepository.SearchAsyn(search);

                if (datas == null) return NotFound($"No se ha encontrado usuario con este filtro {search}");

                return _mapper.Map<List<UserDto>>(datas);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("GetUsersAddress/{id}/{search}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<UserOnlyAddress>>> GetUsersAddress(int id, string search)
        {
            try
            {
                var datas = await _userRepository.GetUsersAddress(id, search);

                if (datas == null) return NotFound($"No se ha encontrado usuario con este filtro {search}");

                return _mapper.Map<List<UserOnlyAddress>>(datas);
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
        public async Task<ActionResult<UserAdressDtos>> One(int id)
        {
            try
            {
                var data = await _userRepository.GetOneAsyn(id);

                if (data == null) return NotFound($"No se ha encontrado este Usuario con el {id}");

                return _mapper.Map<UserAdressDtos>(data);

            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateUserDtos>> Add(CreateUserDtos createUserDtos)
        {
            try
            {
                var user = _mapper.Map<User>(createUserDtos);

                var exitUser = await _authTokenRepository.LoginUser(user.Email);

                if (exitUser != null) return BadRequest("Este Usuario ya existe, Por favor introducir otro.");

                user.Password = _passwordRepository.Hash(user.Password);

                var newUser = await _userRepository.Add(user);

                if (newUser == null) return BadRequest();

                var newUserDto = _mapper.Map<CreateUserDtos>(newUser);

                return CreatedAtAction(nameof(Add), new { id = newUserDto.Id }, newUserDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var exist = await _userRepository.GetOneAsyn(id);

                if (exist == null) return NotFound($"No User found with this id {id}.");

                var data = await _userRepository.Delete(id);

                if (!data) return BadRequest("No se ha podido borrar este Usuario.");

                return Ok("Se ha borrado este Usuario Correctamente.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("ChangeRole/{id}/{role}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChangeRole(int id, string role)
        {
            var IdUser = Convert.ToInt32(User.Claims.First(x => x.Type == "UserID").Value);

            var comprobarRol = await _userRepository.GetOneAsyn(IdUser);

            var data = true;

            var exist = await _userRepository.GetOneAsyn(id);

            if (exist == null) return NotFound($"No User found with this id {id}.");

            if (comprobarRol.Role.ToString() == "SuperAdmin")
            {
                data = await _userRepository.ChangeRole(id, role);

                if (data == false) return BadRequest("No se ha Podido Modificar el rol de este usuario");

                return Ok($"Se ha modificado el rol de este usuario a {role}");
            }

            return Ok("No tiene el privilegio para cambiar rol.");


        }

        [HttpPut("ChangePassowrd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> ChangePassowrd( Password password)
        {
            var IdUser = Convert.ToInt32(User.Claims.First(x => x.Type == "UserID").Value);

            var user = await _userRepository.GetOneAsyn(IdUser);

            var chechk = _passwordRepository.Check(user.Password, password.OldPassword);

            if (chechk == false) return BadRequest("These passwords do not match.");

            var NewPassword = _passwordRepository.Hash(password.Otherpassword);

            var data = await _userRepository.ChangePassowrd(user, NewPassword);

            if (data == false) return BadRequest("No se pudo modificar la contrasena de este usuario.");

            return Ok($"Se ha cambiado la contrasena del Usuario {user.Name} {user.LastName}");



        }
    }
}
