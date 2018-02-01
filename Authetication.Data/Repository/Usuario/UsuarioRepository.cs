using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Data
{
    public class UsuarioRepository :  BaseRepository<Usuario>, IUsuarioRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public UsuarioRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Buscar um candidato por parâmetros
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public Usuario Buscar(string idUsuario)
        {

            var result = _context.Usuario
                .Where(e => e.IdUsuario.ToString() == idUsuario)
                .FirstOrDefault();


            return result;
        }

        /// <summary>
        /// Método para Salvar Usuario e retornar o objeto
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Usuario Salvar(Usuario usuario)
        {

            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}
