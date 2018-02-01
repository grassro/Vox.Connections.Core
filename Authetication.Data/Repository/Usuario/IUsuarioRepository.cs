using System;
using System.Threading.Tasks;
using VoxConnections.Convidados.Core;

namespace VoxConnections.Convidados.Data
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Buscar(string idUsuario);

        Usuario Salvar(Usuario usuario);
    }
}
