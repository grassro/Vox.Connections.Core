using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Data
{
    public interface IGestorRepository : IBaseRepository<Gestor>
    {
        Gestor Detalhe(int id);
        List<Gestor> Listar();
    }
}
