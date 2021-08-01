using AutoMapper;
using Colgameplays.Contract;
using Colgameplays.Dtos.UserDtos;
using Colgameplays.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Colgameplays.Dtos;
using Colgameplays.Model.Enumerations;
using Colgameplays.Model.Option;

namespace Colgameplays.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IEmailSenderRepository _emailSenderRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordRepository _passwordRepositorio;
        private readonly IUserRepository _userRepository;

        public AuthController(IAuthRepository authRepository, IMapper mapper, IPasswordRepository passwordRepositorio , IUserRepository userRepository, IEmailSenderRepository emailSenderRepository)
        {
            _authRepository = authRepository;
            _emailSenderRepository = emailSenderRepository;
            _mapper = mapper;
            _passwordRepositorio = passwordRepositorio;
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Authentication(LoginUser login)
        {
            try
            {
                var valid = await IsValidUse(login);

                if (valid.Item1)
                {
                    var token = _authRepository.GenerateToken(valid.Item2);
                    return Ok(token);
                }

                return BadRequest("Incorrect user or password.");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        private async Task<(bool, User)> IsValidUse(LoginUser login)

        {
            var user = await _authRepository.LoginUser(login.Email);

            if (user == null) return (false, user);

            var isvalid = _passwordRepositorio.Check(user.Password, login.Password);

            if (isvalid == false) return (false, user);

            return (isvalid, user);

        }


        [HttpGet("renewnew")]
        [Authorize]
        public async Task<ActionResult<InfoRenewnewDto>> Renewnew()
        {
            var userID = Convert.ToInt32(User.Claims.First(x => x.Type == "UserID").Value);

            var user = await _authRepository.UserID(userID);

            var token = _authRepository.GenerateToken(user);

            var usuarioDto = _mapper.Map<UserDto>(user);

            var data = new InfoRenewnewDto()
            {
                Token = token,
                User = usuarioDto
            };

            return data;
        }

        [HttpPost("registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Registrar(RegisterUserDto usuarioDto)
        {

            try
            {
                var user = _mapper.Map<User>(usuarioDto);

                var exitUser = await _authRepository.LoginUser(user.Email);

                if (exitUser != null) return BadRequest("This User already exists, Please enter another.");

                user.Role = (Roles)Enum.Parse(typeof(Roles), "User");

                user.Password = _passwordRepositorio.Hash(user.Password);

                var NewUser = await _authRepository.RegistrarUser(user);

                if (NewUser == null) return BadRequest("This user could not be registered.");

                var NewUserDtos = _mapper.Map<UserDto>(NewUser);

                await _emailSenderRepository.SendEmailCreateUserAsync(NewUserDtos);

                return CreatedAtAction(nameof(Registrar), new { id = NewUserDtos.Id }, NewUserDtos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ForgotPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ForgotPassword(ForgotPassword forgotPassword)
        {
            var user = await _authRepository.LoginUser(forgotPassword.Email);

            if (user == null) return NotFound("Este usuario no existe.");

            var token = _authRepository.GenerateToken(user);

            var message = await _emailSenderRepository.ForgotPassword(user, token);

            if (message == false) return BadRequest("Se ha producido un error a enviar un mensaje por correo.");

            return Ok("Revise su correo electronico y sigua todas la intruciones dadas.");

        }

        [HttpPost("ResetPassword")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var email = User.Claims.First(x => x.Type == "Email").Value.ToString() ;

            var data = await _authRepository.LoginUser(email);

            if (data == null) return BadRequest("No se ha encontrado este Usuario");

            if (resetPasswordModel.Password != resetPasswordModel.ConfirmPassword) return BadRequest("The password no coinciden");

            var RPassowrd =  _passwordRepositorio.Hash(resetPasswordModel.ConfirmPassword);

            var user = await _userRepository.ChangePassowrd(data, RPassowrd);

            if (user == false) return BadRequest("No se ha podido cambiar la contrasena.");

            return Ok("Contrasena cambiada");
        }
    }
}
