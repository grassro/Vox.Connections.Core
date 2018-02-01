using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Data
{
    public interface IIdiomasVagasRepository : IBaseRepository<IdiomaVaga>
    {
        int Salvar(IdiomaVaga idiomaVaga);
    }
}
