using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Application.Services
{
    public interface IIdiomasVagasService : IBaseService<IdiomaVaga>
    {
        int Salvar(IdiomaVaga item);
    }
}
