
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Data
{
    public class CandidatoRepository : BaseRepository<Candidato>, ICandidatoRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public CandidatoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Detalhe do candidato
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Candidato Detalhe(int id)
        {
            var candidato = _context.Candidato
                .Include(c => c.Curriculo)
                .Include(c => c.Idiomas)
                .Where(c => c.IdCandidato == id).FirstOrDefault();

            return candidato;
        }

        /// <summary>
        /// Listagem de todos os Candidatos
        /// </summary>
        /// <returns></returns>
        public List<Candidato> Listar()
        {
            var list = _context.Candidato
                        .Include(c => c.Curriculo)
                        .Include(c => c.Idiomas)
                        .Where(c => c.Ativo == true).ToList();

            return list;
        }

        /// <summary>
        /// Listagem de candidatos pelo parâmetro
        /// </summary>
        /// <param name="candidatoBusca"></param>
        /// <returns></returns>
        public List<Candidato> Buscar(CandidatoBusca candidatoBusca)
        {

            var idiomas = _context.IdiomaCandidato.Where(i => i.NomeIdioma == candidatoBusca.Idioma).Where(s => s.NomeIdioma == candidatoBusca.Idioma).Select(s => s.NomeIdioma);

            var list = _context.Candidato
                        .Include(c => c.Curriculo)
                        .Include(c => c.Idiomas)
                        .Select(c => c);


            if (!string.IsNullOrEmpty(candidatoBusca.AreaAtuacao))
            {
                list = list.Where(c => c.AreaAtuacao == candidatoBusca.AreaAtuacao);
            }

            if (!string.IsNullOrEmpty(candidatoBusca.NivelFuncao))
            {
                list = list.Where(c => c.NivelFuncao == candidatoBusca.NivelFuncao);
            }

            if (!string.IsNullOrEmpty(candidatoBusca.NivelEscolaridade))
            {
                list = list.Where(c => c.NivelEscolaridade == candidatoBusca.NivelEscolaridade);
            }

            if (!string.IsNullOrEmpty(candidatoBusca.Idioma))
            {
                list = list.Where(c => idiomas.Contains(candidatoBusca.Idioma));
            }

            var retorno = list.ToList();

            return retorno;

        }
    }
}
