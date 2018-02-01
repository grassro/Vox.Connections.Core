using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Data
{
    public class CurriculoRepository : BaseRepository<Curriculo>, ICurriculoRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public CurriculoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Método para Salvar Currículo
        /// </summary>
        /// <param name="curriculo"></param>
        /// <returns></returns>
        public int Salvar(Curriculo curriculo)
        {

            _context.Curriculo.Add(curriculo);
            _context.SaveChanges();

            return curriculo.IdCurriculo;
        }
    }
}
