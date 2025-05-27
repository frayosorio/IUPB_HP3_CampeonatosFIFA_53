using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CampeonatosFifaContext context;

        public UsuarioRepositorio(CampeonatosFifaContext context)
        {
            this.context = context;
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

        public async Task<Usuario> ValidarUsuario(string NombreUsuario, string Clave)
        {
            return await context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == NombreUsuario && u.Clave == Clave);
        }
    }
}
