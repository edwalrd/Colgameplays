using Colgameplays.Contract;
using Colgameplays.Dtos.UserDtos;
using Colgameplays.Entities;
using Colgameplays.Model.Option;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class EmailSenderRepository: IEmailSenderRepository
    {
        private SmtpClient Cliente { get; }
        private EmailSenderOptions Options { get; }

        public string message;

        public EmailSenderRepository(IOptions<EmailSenderOptions> options)
        {
            Options = options.Value;
            Cliente = new SmtpClient()
            {
                Host = Options.Host,
                Port = Options.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Options.Email, Options.Password),
                EnableSsl = Options.EnableSsl,
            };
        }

        public Task SendEmailCreateUserAsync(UserDto user)
        {
            message = $"Bienvenido {user.Name}  {user.LastName}";

            var correo = new MailMessage(from: Options.Email, to: user.Email, subject: "Bienvenido ", body: message);
            correo.IsBodyHtml = true;
            return Cliente.SendMailAsync(correo);
        }

        public async Task<bool> ForgotPassword (User user, string token)
        {
            message = $"Hola, {user.Name} {user.LastName} Recuperar password de click aqui /n {token}";

            var correo = new MailMessage(from: Options.Email, to: user.Email, subject: "Forgot Password ", body: message);
            correo.IsBodyHtml = true;
           ;
            await Cliente.SendMailAsync(correo);

            return true;
        }

    }
}
