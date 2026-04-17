using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RetoTecnico.Data;
using RetoTecnico.Domain;
using RetoTecnico.Model;
using RetoTecnico.Service;
using static System.Net.Mime.MediaTypeNames;

namespace RetoTecnico.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Jwtservice jwt;

        public UserController(Jwtservice jwtservice)
        {
            jwt = jwtservice;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult<UserLoginResponse>> Login(UserLoginRequest login)
        {
            var auth = await jwt.Authenticate(login);
            if (auth is null)
            {
                return Unauthorized(new
                {
                    codigo = "CREDENCIALES_INVALIDAS",
                    mensaje = "Usuario o contraseña incorrectos"
                });
            }

            return auth;
        }
    }
}
