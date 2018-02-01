using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Data
{
    public interface ICurriculoRepository : IBaseRepository<Curriculo>
    {
        int Salvar(Curriculo curriculo);
    }
}
