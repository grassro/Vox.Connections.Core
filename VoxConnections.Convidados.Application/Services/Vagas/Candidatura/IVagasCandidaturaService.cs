using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Application
{
    public interface IVagasCandidaturaService : IBaseService<VagasCandidatura>
    {
        Task Candidatar(VagasCandidatura candidatura);
    }
}
