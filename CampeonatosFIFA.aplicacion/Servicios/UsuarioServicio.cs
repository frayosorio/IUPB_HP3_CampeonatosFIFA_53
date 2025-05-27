using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.DTOs;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CampeonatosFIFA.aplicacion.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio repositorio;
        private readonly string _claveSecreta;

        public UsuarioServicio(IUsuarioRepositorio repositorio, IConfiguration config)
        {
            this.repositorio = repositorio;
            _claveSecreta = config["Jwt:Key"];
        }
        public Task<Usuario> Agregar(Usuario Usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> Buscar(int Tipo, string Dato)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Modificar(Usuario Usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        private string GenerarToken(string nombreUsuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, nombreUsuario)
        };

            var token = new JwtSecurityToken(
                issuer: "apiCampeonatosFIFA",
                audience: "apiCampeonatosFIFA",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public async Task<UsuarioDto> ValidarUsuario(string NombreUsuario, string Clave)
        {
            var usuarioDto = new UsuarioDto();
            var usuario = await repositorio.ValidarUsuario(NombreUsuario, Clave);
            if (usuario != null)
            {
                usuarioDto.usuario = usuario;
                usuarioDto.token = GenerarToken(NombreUsuario);
            }
            return usuarioDto;
        }
    }
}
