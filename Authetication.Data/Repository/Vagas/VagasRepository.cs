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
    public class VagasRepository : BaseRepository<Vagas>, IVagasRepository
    {

        #region Atributos

        private readonly DataContext _context;

        #endregion

        #region Construtor

        public VagasRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        #endregion

        public Vagas Detalhe(int id)
        {
            var candidato = _context.Vagas
                .Include(c => c.Headhunter)
                .Include(c => c.Idiomas)
                .Where(c => c.IdVaga == id).FirstOrDefault();

            return candidato;
        }

        public List<Vagas> Buscar(VagasBusca vagas)
        {
            var idiomas = _context.IdiomaVaga.Where(i => i.NomeIdioma == vagas.Idioma).Select(s => s.NomeIdioma);

            var list = _context.Vagas
                        .Include(c => c.Headhunter)
                        .Include(c => c.Idiomas)
                        .Select(v => v);

            if (!string.IsNullOrEmpty(vagas.AreaAtuacao))
            {
                list = list.Where(c => c.AreaAtuacao == vagas.AreaAtuacao);
            }

            if (!string.IsNullOrEmpty(vagas.NivelFuncao))
            {
                list = list.Where(c => c.NivelFuncao == vagas.NivelFuncao);
            }

            if (!string.IsNullOrEmpty(vagas.TipoContratacao))
            {
                list = list.Where(c => c.TipoContratacao == vagas.TipoContratacao);
            }

            if (!string.IsNullOrEmpty(vagas.NivelEscolaridade))
            {
                list = list.Where(c => c.NivelEscolaridade == vagas.NivelEscolaridade);
            }

            if (!string.IsNullOrEmpty(vagas.Idioma))
            {
                list = list.Where(c => idiomas.Contains(vagas.Idioma));
            }

            var retorno = list.ToList();

            return retorno;
        }

        public List<Vagas> Listar(string idUsuario)
        {

            var candidatura = _context.VagasCandidatura.Where(x => x.IdUsuario == idUsuario).Select(x => x.IdVaga).ToList();

            var result = _context.Vagas
                        .Include(v => v.Headhunter)
                        .Include(v => v.Idiomas)
                        .Select(v => new Vagas()
                        {
                            AreaAtuacao = v.AreaAtuacao,
                            Cidade = v.Cidade,
                            UF = v.UF,
                            Descricao = v.Descricao,
                            IdVaga = v.IdVaga,
                            Idiomas = v.Idiomas,
                            Headhunter = v.Headhunter,
                            IdHeadhunter = v.IdHeadhunter,
                            NivelEscolaridade = v.NivelEscolaridade,
                            NivelFuncao = v.NivelFuncao,
                            TipoContratacao = v.TipoContratacao,
                            Titulo = v.Titulo,
                            Candidatou = candidatura.Contains(v.IdVaga) ? true : false
                        }).Take(50).ToList();

            return result;
        }
    }
}
