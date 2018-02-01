using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Data
{
    public class IdiomasCandidatoRepository : BaseRepository<IdiomaCandidato>, IIdiomasCandidatoRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public IdiomasCandidatoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Método para Salvar Idioma e retornar Id
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public int Salvar(IdiomaCandidato idioma)
        {

            _context.IdiomaCandidato.Add(idioma);
            _context.SaveChanges();

            return idioma.IdIdioma;
        }
    }
}
