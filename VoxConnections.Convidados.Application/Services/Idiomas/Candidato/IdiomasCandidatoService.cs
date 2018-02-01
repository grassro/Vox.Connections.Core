using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Application.Services
{
    public class IdiomasCandidatoService : BaseService<IdiomaCandidato>, IIdiomasCandidatoService
    {
        #region Atributos

        private readonly IIdiomasCandidatoRepository _repository;

        #endregion

        #region Construtor

        public IdiomasCandidatoService(IBaseRepository<IdiomaCandidato> baseRepository, IIdiomasCandidatoRepository repository) 
            : base(baseRepository)
        {
            _repository = repository;
        }

        #endregion

        public int Salvar(IdiomaCandidato item)
        {
            return _repository.Salvar(item);
        }

    }
}
