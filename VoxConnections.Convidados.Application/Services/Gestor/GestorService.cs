using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;

namespace VoxConnections.Convidados.Application
{
    public class GestorService : BaseService<Gestor>, IGestorService
    {
        #region Atributos

        private readonly IGestorRepository _repository;
        private readonly ICurriculoService _curriculoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IIdiomasGestorService _idiomasService;

        #endregion

        #region Construtor

        /// <summary>
        ///  Implementando Interfaces
        /// </summary>
        /// <param name="repository"></param>
        public GestorService(IBaseRepository<Gestor> baseRepository, IGestorRepository repository, ICurriculoService curriculoService, IUsuarioService usuarioService, IIdiomasGestorService idiomasService)
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
        /// Método para Gravar Gestor
        /// </summary>
        /// <param name="gestor"></param>
        public void Gravar(Gestor gestor, string senha)
        {

            try
            {

                gestor.IdCurriculo = _curriculoService.Salvar(gestor.Curriculo);
                _repository.Add(gestor);

                _usuarioService.AlteraSenha(senha, gestor.IdUsuario.ToString());

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
        public Gestor Detalhe(int id)
        {
            return _repository.Detalhe(id);
        }

        /// <summary>
        /// Listagem de todos os Gestores
        /// </summary>
        /// <returns></returns>
        public List<Gestor> Listar()
        {

            return _repository.Listar();
        }

        #endregion
    }
}
