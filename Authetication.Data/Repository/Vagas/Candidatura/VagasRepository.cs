using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Data
{
    public class VagasCandidaturaRepository : BaseRepository<VagasCandidatura>, IVagasCandidaturaRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public VagasCandidaturaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

      
        #endregion

        public Vagas Detalhe(int id)
        {
            var candidato =  _context.Vagas
               .Include(c => c.Idiomas)
               .Where(c => c.IdVaga == id).FirstOrDefault();

            return candidato;
        }

        public List<Vagas> Buscar(VagasBusca vagas)
        {
            var idiomas = _context.IdiomaVaga.Where(i => i.NomeIdioma == vagas.Idioma).Select(s => s.IdIdioma);

            var list = _context.Vagas
                        .Include(c => c.Idiomas)
                        .Where(c => c.AreaAtuacao == vagas.AreaAtuacao
                                 && c.NivelEscolaridade == vagas.NivelEscolaridade
                                 && c.NivelFuncao == vagas.NivelFuncao).ToList();

            return list;
        }


    }
}
