using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Application
{
    public interface IHeadhunterService : IBaseService<Headhunter>
    {
        Headhunter Detalhe(int id);
        List<Headhunter> Listar();
        void Gravar(Headhunter candidato, string senha);
    }
}
