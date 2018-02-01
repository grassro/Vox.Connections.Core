using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Data
{
    public class GestorRepository : BaseRepository<Gestor>, IGestorRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public GestorRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Detalhe do Gestor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Gestor Detalhe(int id)
        {
            var gestor = _context.Gestor
                .Include(c => c.Curriculo)
                .Include(c => c.Idiomas)
                .Where(c => c.IdGestor == id).FirstOrDefault();

            return gestor;
        }

        /// <summary>
        /// Listagem de todos os Candidatos
        /// </summary>
        /// <returns></returns>
        public List<Gestor> Listar()
        {
            var list = _context.Gestor
                        .Include(c => c.Curriculo)
                        .Include(c => c.Idiomas)
                        .Where(c => c.Ativo == true).ToList();

            return list;
        }

    }
}
