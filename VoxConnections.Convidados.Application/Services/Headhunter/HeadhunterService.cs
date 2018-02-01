using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;

namespace VoxConnections.Convidados.Application
{
    public class HeadhunterService : BaseService<Headhunter>, IHeadhunterService
    {
        #region Atributos

        private readonly IHeadhunterRepository _repository;
        private readonly ICurriculoService _curriculoService;
        private readonly IUsuarioService _usuarioService;

        #endregion

        #region Construtor

        /// <summary>
        ///  Implementando Interfaces
        /// </summary>
        /// <param name="repository"></param>
        public HeadhunterService(IBaseRepository<Headhunter> baseRepository, IHeadhunterRepository repository, ICurriculoService curriculoService, IUsuarioService usuarioService)
            : base(baseRepository)
        {
            _repository = repository;
            _curriculoService = curriculoService;
            _usuarioService = usuarioService;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Método para Gravar Headhunter
        /// </summary>
        /// <param name="headhunter"></param>
        public void Gravar(Headhunter headhunter, string senha)
        {

            try
            {

                headhunter.Ativo = true;
                _repository.Add(headhunter);

                _usuarioService.AlteraSenha(senha, headhunter.IdUsuario.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Detalhe do Gestor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Headhunter Detalhe(int id)
        {
            return _repository.Detalhe(id);
        }

        /// <summary>
        /// Listagem de todos os Gestores
        /// </summary>
        /// <returns></returns>
        public List<Headhunter> Listar()
        {

            return _repository.Listar();
        }

        #endregion
    }
}
