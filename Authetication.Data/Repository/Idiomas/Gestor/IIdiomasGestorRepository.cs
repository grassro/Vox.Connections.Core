using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Data
{
    public interface IIdiomasGestorRepository : IBaseRepository<IdiomaGestor>
    {
        int Salvar(IdiomaGestor curriculo);
    }
}
