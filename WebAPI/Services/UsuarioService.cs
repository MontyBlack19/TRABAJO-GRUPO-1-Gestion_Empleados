using Gestion_Empleados.Models;
using Gestion_Empleados.Operations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using WebAPI.DTOs;


namespace WebAPI.Services
{
    public class UsuarioService
    {
        private readonly UsuarioDAO _usuarioDAO;
        private readonly IConfiguration _configuration;

        public UsuarioService(UsuarioDAO usuarioDAO, IConfiguration configuration)
        {
            _usuarioDAO = usuarioDAO;
            _configuration = configuration;
        }

        public Usuario? login(loginDTO loginDTO)
        {
            var usuario = _usuarioDAO.login(loginDTO.Username, loginDTO.PasswordHash);
            return usuario;
        }

        public string GenerarToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);  //seguridad implementada en caso de inyecciones de keys no emitidas por el servidor
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor // asigna el token y almacena en usuario con su id para evitar repetidos 
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim("IdUsuario", usuario.IdUsuario.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) //asegura que no sea falsificado 
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); //crea en memoria
            return tokenHandler.WriteToken(token); //convierte cadena y envía al front
        }

        public void EnviarCorreoCredenciales(string correoDestino, string asunto, string cuerpo, bool esHtml)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            var remitente = emailSettings["From"];
            var smtpServer = emailSettings["SmtpServer"];
            var puerto = int.Parse(emailSettings["Port"]);
            var usuarioSMTP = emailSettings["Username"];
            var passwordSMTP = emailSettings["Password"];

            var mensaje = new MailMessage
            {
                From = new MailAddress(remitente, "Sistema de RR.HH."),
                Subject = asunto,
                Body = cuerpo,
                IsBodyHtml = esHtml
            };

            mensaje.To.Add(correoDestino);

            using var smtp = new SmtpClient(smtpServer, puerto)
            {
                Credentials = new NetworkCredential(usuarioSMTP, passwordSMTP),
                EnableSsl = true
            };

            try
            {
                smtp.Send(mensaje);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message);
            }
        }

        public bool registrar(UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var usuario = new Usuario
            {
                Username = usuarioRegistroDTO.Username,
                PasswordHash = usuarioRegistroDTO.PasswordHash,
                Activo = usuarioRegistroDTO.Activo
            };

            bool registrado = _usuarioDAO.registrar(usuario);

            if (registrado)
            {
                string asunto = "Credenciales de acceso al sistema";
                string mensaje = $@"
                <html>
                  <body style='margin:0; padding:0;'>
                    <div style='
                      background-image: url(https://slidevilla.com/wp-content/uploads/edd/2019/04/81ae87aab174dc8622a30bada3ac2747-1.jpg);
                      background-size: cover;
                      background-repeat: no-repeat;
                      background-position: center;
                      width: 100%;
                      height: 100vh;
                      padding: 40px;
                      box-sizing: border-box;
                      font-family: Arial, sans-serif;
                      color: #ffffff;
                    '>
                      <div style='
                        background-color: rgba(0, 0, 0, 0.6);
                        padding: 30px;
                        border-radius: 10px;
                        max-width: 500px;
                        margin: auto;
                      '>
                        <h2 style='margin-top: 0; color: #90CAF9;'>Bienvenido al sistema de RR.HH.</h2>
                        <p>Tu cuenta ha sido creada exitosamente.</p>
                        <p><strong>Usuario:</strong> {usuario.Username}</p>
                        <p><strong>Contraseña:</strong> {usuarioRegistroDTO.PasswordHash}</p>
                        <p style='color: #FFEB3B;'>Por favor, cambia tu contraseña al iniciar sesión.</p>
                      </div>
                    </div>
                  </body>
                </html>";
                EnviarCorreoCredenciales(usuarioRegistroDTO.Correo, asunto, mensaje, true);
            }

            return registrado;
        }

        public bool actualizar(ActualizarUsuarioDTO auDTO)
        {
            var usuario = _usuarioDAO.login(auDTO.Username, auDTO.PasswordActual);
            if (usuario == null)
            {
                return false;
            }
            return _usuarioDAO.actualizar(auDTO.Username, auDTO.PasswordActual ,auDTO.PasswordNueva);
        }
    }
}
