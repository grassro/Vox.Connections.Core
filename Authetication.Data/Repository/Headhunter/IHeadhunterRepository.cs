using System;
using System.Collections.Generic;
using System.Text;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Data
{
    public interface IHeadhunterRepository : IBaseRepository<Headhunter>
    {
        Headhunter Detalhe(int id);
        List<Headhunter> Listar();
    }
}