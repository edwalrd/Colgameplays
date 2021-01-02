using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Colgameplays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepositorio _IAuthRepositorio;
        private readonly IMapper _mapper;
        private readonly IPasswordRepositorio _passwordRepositorio;

        public AuthController(IConfiguration  configuration , IAuthRepositorio usuarioRepositorio , IMapper mapper , IPasswordRepositorio passwordRepositorio)
        {
            _configuration = configuration;
            _IAuthRepositorio = usuarioRepositorio;
            _mapper = mapper;
            _passwordRepositorio = passwordRepositorio;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Authentication(LoginUser login)
        {
            var validator = await IsValidUse(login);

            if (validator.Item1)
            {
                var token = GenerateToken(validator.Item2);
                return Ok(new { token });
            }

            return BadRequest("Usuario o Contraseña Incorrecta.");

        }

        private async  Task<(bool , Usuario)> IsValidUse(LoginUser login)
        {
            var user = await _IAuthRepositorio.LoginUser(login.user);

            var isvalid = _passwordRepositorio.Check(user.Password , login.password);

            if (user == null || isvalid == false) return (false, user);

            return (isvalid, user);
        }

        private string GenerateToken(Usuario user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims

            var claims = new[]
            {
                new Claim("UserID", user.Id.ToString()),
                new Claim(ClaimTypes.Role,  user.Role.ToString()),
            };

            //Payload

            var payload = new JwtPayload
          (
              _configuration["JwtSettings:Issuer"],
              _configuration["JwtSettings:Audience"],
              claims,
              DateTime.Now,
              DateTime.UtcNow.AddHours(12)
          );

            //Token

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioDtos>> Registrar (UsuarioDtos usuarioDto)
        {

            try { 

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            var exitUser = await _IAuthRepositorio.LoginUser(usuario.User);

            if (exitUser != null) return BadRequest("Este Usuario ya existe, Por favor introducir otro.");

            usuario.Role = Roles.user;
            usuario.Password = _passwordRepositorio.Hash(usuario.Password);

            var newUsuario = await _IAuthRepositorio.RegistrarUser(usuario);

            if (newUsuario == null)
            {
                return BadRequest();
            }

            var newUsuarioDto = _mapper.Map<UsuarioDtos>(newUsuario);

            return CreatedAtAction(nameof(Registrar), new { id = newUsuarioDto.Id }, newUsuarioDto);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet("renewnew")]
        [Authorize]
        public async  Task<ActionResult<InfoRenewnewDto>> Renewnew()
        {
                var IdUser = Convert.ToInt32(User.Claims.First(x => x.Type == "UserID").Value);

                var usuario = await _IAuthRepositorio.UserID(IdUser);

                var token = GenerateToken(usuario);

                var usuarioDto = _mapper.Map<GetUsuarioDto>(usuario);

                 var data = new InfoRenewnewDto()
                     { 
                            Token = token,
                            Usuario = usuarioDto
                     };

                     return data; 
        }

    }

} 


