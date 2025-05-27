using CampeonatosFIFA.Dominio.DTOs;
using CampeonatosFIFA.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatosFIFA.Core.Servicios
{
    public interface IUsuarioServicio
    {
        Task<UsuarioDto> ValidarUsuario(String NombreUsuario, String Clave);

        Task<IEnumerable<Usuario>> ObtenerTodos();

        Task<Usuario> Obtener(int Id);

        Task<Usuario> Agregar(Usuario Usuario);

        Task<Usuario> Modificar(Usuario Usuario);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Usuario>> Buscar(int Tipo, string Dato);
    }
}
