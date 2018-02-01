using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Application.Services
{
    public class IdiomasVagasService : BaseService<IdiomaVaga>, IIdiomasVagasService
    {
        #region Atributos

        private readonly IIdiomasVagasRepository _repository;

        #endregion

        #region Construtor

        public IdiomasVagasService(IBaseRepository<IdiomaVaga> baseRepository, IIdiomasVagasRepository repository) 
            : base(baseRepository)
        {
            _repository = repository;
        }

        #endregion

        public int Salvar(IdiomaVaga item)
        {
            return _repository.Salvar(item);
        }

    }
}
