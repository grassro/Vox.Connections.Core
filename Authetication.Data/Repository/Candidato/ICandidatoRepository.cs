using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Data
{
    public interface ICandidatoRepository : IBaseRepository<Candidato>
    {
        Candidato Detalhe(int id);
        List<Candidato> Listar();
        List<Candidato> Buscar(CandidatoBusca candidatoBusca);
    }
}
