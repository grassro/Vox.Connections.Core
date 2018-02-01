using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data.Repository;

namespace VoxConnections.Convidados.Application.Services
{
    public interface IIdiomasCandidatoService : IBaseService<IdiomaCandidato>
    {
        int Salvar(IdiomaCandidato item);
    }
}
