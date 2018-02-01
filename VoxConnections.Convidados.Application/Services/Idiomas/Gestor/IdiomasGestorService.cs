using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Application.Services
{
    public class IdiomasGestorService : BaseService<IdiomaGestor>, IIdiomasGestorService
    {
        #region Atributos

        private readonly IIdiomasGestorRepository _repository;

        #endregion

        #region Construtor

        public IdiomasGestorService(IBaseRepository<IdiomaGestor> baseRepository, IIdiomasGestorRepository repository) 
            : base(baseRepository)
        {
            _repository = repository;
        }

        #endregion

        public int Salvar(IdiomaGestor item)
        {
            return _repository.Salvar(item);
        }

    }
}
