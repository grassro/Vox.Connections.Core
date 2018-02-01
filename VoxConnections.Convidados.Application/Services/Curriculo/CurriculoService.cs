using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Application.Services
{
    public class CurriculoService : BaseService<Curriculo>, ICurriculoService
    {

        #region Atributos

        private readonly ICurriculoRepository _repository;

        #endregion

        #region Construtor

        public CurriculoService(IBaseRepository<Curriculo> baseRepository, ICurriculoRepository repository) 
            : base(baseRepository)
        {
            _repository = repository;
        }

        #endregion

        public int Salvar(Curriculo curriculo)
        {
            return _repository.Salvar(curriculo);
        }
    }
}
