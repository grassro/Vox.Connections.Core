using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;

namespace VoxConnections.Convidados.Application.Services
{
    public class CandidatoService : BaseService<Candidato>, ICandidatoService
    {
        #region Atributos

        private readonly ICandidatoRepository _repository;
        private readonly ICurriculoService _curriculoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IIdiomasCandidatoService _idiomasService;

        #endregion

        #region Construtor

        /// <summary>
        ///  Implementando Interfaces
        /// </summary>
        /// <param name="repository"></param>
        public CandidatoService(IBaseRepository<Candidato> baseRepository, ICandidatoRepository repository, ICurriculoService curriculoService, IUsuarioService usuarioService, IIdiomasCandidatoService idiomasService)
            : base(baseRepository)
        {
            _repository = repository;
            _curriculoService = curriculoService;
            _usuarioService = usuarioService;
            _idiomasService = idiomasService;
        }

        #endregion

        #region Métodos Públicos


        /// <summary>
        /// Método para Gravar Candidato
        /// </summary>
        /// <param name="candidato"></param>
        public void Gravar(Candidato candidato, string senha)
        {

            try
            {

                candidato.IdCurriculo = _curriculoService.Salvar(candidato.Curriculo);

                candidato.Ativo = true;
                _repository.Add(candidato);

                foreach (var item in candidato.Idiomas)
                {
                    if (candidato.IdCandidato > 0)
                    {
                        item.IdCandidato = candidato.IdCandidato;
                    }

                     _idiomasService.Salvar(item);

                }

                _usuarioService.AlteraSenha(senha, candidato.IdUsuario.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Detalhe do candidato
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Candidato Detalhe(int id)
        {
            return _repository.Detalhe(id);
        }

        /// <summary>
        /// Listagem de todos os Candidatos
        /// </summary>
        /// <returns></returns>
        public List<Candidato> Listar()
        {

            return _repository.Listar();
        }

        /// <summary>
        /// Buscar Candidatos
        /// </summary>
        /// <param name="candidatoBusca"></param>
        /// <returns></returns>
        public List<Candidato> Buscar(CandidatoBusca candidatoBusca)
        {
            return _repository.Buscar(candidatoBusca);
        }

        public void Alterar(Candidato model)
        {
            _curriculoService.Update(model.Curriculo);

            _repository.Update(model);


        }


        #endregion
    }
}
