using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatosFIFA.Presentacion.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuarioControlador : ControllerBase
    {
        private readonly IUsuarioServicio servicio;

        public UsuarioControlador(IUsuarioServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("login/{NombreUsuario}/{Clave}")]
        [AllowAnonymous]
        public async Task<UsuarioDto> Login(String NombreUsuario, String Clave)
        {
            return await servicio.ValidarUsuario(NombreUsuario, Clave);
        }
    }
}
