using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Application
{
    public interface IVagasService : IBaseService<Vagas>
    {
        List<Vagas> Buscar(VagasBusca vagas);
        Vagas Detalhe(int id);
        List<Vagas> Listar(string idUsuario);
        void Encerrar(int idVaga);
        void Salvar(Vagas model);
    }
}
