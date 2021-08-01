using Colgameplays.Dtos.UserDtos;
using Colgameplays.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
   public interface IEmailSenderRepository
    {
        //Enviar mensaje de bienvenida a crear un usuario.
        Task SendEmailCreateUserAsync(UserDto user);

        Task<bool> ForgotPassword(User user, string token);
    }
}
