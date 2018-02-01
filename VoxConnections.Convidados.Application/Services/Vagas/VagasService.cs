using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;

namespace VoxConnections.Convidados.Application
{
    public class VagasService : BaseService<Vagas>, IVagasService
    {

        #region Atributos

        private readonly IVagasRepository _repository;
        private readonly IIdiomasVagasRepository _idiomaRepository;

        #endregion

        #region Construtor

        public VagasService(IBaseRepository<Vagas> baseRepository, IVagasRepository repository, IIdiomasVagasRepository idiomaRepository)
            : base(baseRepository)
        {
            _repository = repository;
            _idiomaRepository = idiomaRepository;
        }

        #endregion

        public List<Vagas> Buscar(VagasBusca vagas)
        {
           return _repository.Buscar(vagas);
        }
       
        public Vagas Detalhe(int id)
        {
            return _repository.Detalhe(id);
        }

        public void Encerrar(int idVaga)
        {
            var vaga = _repository.GetById(idVaga);
            vaga.Ativo = false;

            _repository.Update(vaga);

        }

        public List<Vagas> Listar(string idUsuario)
        {
            return _repository.Listar(idUsuario);
        }

        public void Salvar(Vagas model)
        {

            _repository.Add(model);

            //foreach (var item in model.Idiomas)
            //{
            //    if (model.IdVaga > 0)
            //    {
            //        item.IdVaga = model.IdVaga;
            //    }

            //    _idiomaRepository.Salvar(item);

            //}

        }
    }
}
