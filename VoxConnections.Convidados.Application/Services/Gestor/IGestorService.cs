using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Application
{
    public interface IGestorService : IBaseService<Gestor>
    {
        Gestor Detalhe(int id);
        List<Gestor> Listar();
       void Gravar(Gestor candidato, string senha);
    }
}
