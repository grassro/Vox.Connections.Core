using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Application.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Usuario Buscar(string idUsuario);
        void InsereUsuarios(List<Usuario> usuarios);
        void AlteraSenha(string senha, string idUsuario);
    }
}
