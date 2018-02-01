using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Data
{
    public interface IVagasRepository : IBaseRepository<Vagas>
    {
        Vagas Detalhe(int id);
        List<Vagas> Buscar(VagasBusca vagas);
        List<Vagas> Listar(string idUsuario);
    }
}
