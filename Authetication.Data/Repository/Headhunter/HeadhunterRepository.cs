using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Data
{
    public class HeadhunterRepository : BaseRepository<Headhunter>, IHeadhunterRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public HeadhunterRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Detalhe do Headhunter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Headhunter Detalhe(int id)
        {
            var head = _context.Headhunter
                .Where(c => c.IdHeadhunter == id).FirstOrDefault();

            return head;
        }

        /// <summary>
        /// Listagem de todos os Headhunters
        /// </summary>
        /// <returns></returns>
        public List<Headhunter> Listar()
        {
            var list = _context.Headhunter
                        .Where(c => c.Ativo == true).ToList();

            return list;
        }

    }
}
