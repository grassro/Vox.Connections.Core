using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Application.Services
{
    public interface ICurriculoService : IBaseService<Curriculo>
    {
        int Salvar(Curriculo curriculo);
    }
}
