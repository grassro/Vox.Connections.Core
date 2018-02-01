using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Application.Services
{
    public interface ICandidatoService : IBaseService<Candidato>
    {
        Candidato Detalhe(int id);
        List<Candidato> Listar();
        List<Candidato> Buscar(CandidatoBusca candidatoBusca);
        void Gravar(Candidato candidato, string senha);
        void Alterar(Candidato model);
    }
}
