using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Data
{
    public class IdiomasGestorRepository : BaseRepository<IdiomaGestor>, IIdiomasGestorRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public IdiomasGestorRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Método para Salvar Idioma e retornar Id
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public int Salvar(IdiomaGestor idioma)
        {

            _context.IdiomaGestor.Add(idioma);
            _context.SaveChanges();

            return idioma.IdIdioma;
        }
    }
}
