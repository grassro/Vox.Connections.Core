using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vox.Abstraction.API;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Data;

namespace VoxConnections.Convidados.Application
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        #region Atributos

        private readonly IUsuarioRepository _repository;

        #endregion

        #region Construtor

        /// <summary>
        ///  Implementando Interfaces
        /// </summary>
        /// <param name="repository"></param>
        public UsuarioService(IBaseRepository<Usuario> baseRepository, IUsuarioRepository repository)
            : base(baseRepository)
        {
            _repository = repository;
        }

        #endregion

        #region Métodos Publicos
        public Usuario Buscar(string idUsuario)
        {

            var usuario =  _repository.Buscar(idUsuario);

            if (usuario.Cadastrado)
            {
                throw new Exception("Usuário Cadastrado");
            }
            else
            {
                return usuario;

            }

        }

        public void InsereUsuarios(List<Usuario> usuarios)
        {

            try
            {
                foreach (var usuario in usuarios)
                {
                    var result = _repository.Salvar(usuario);
                    EnviarEmail(result);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void AlteraSenha(string senha, string idUsuario)
        {
            try
            {

                var usuario = _repository.Buscar(idUsuario);
                usuario.Senha = senha;
                usuario.Cadastrado = true;

                _repository.Update(usuario);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


        #region Métodos Privados

        private void EnviarEmail(Usuario usuario)
        {
            APIRest apiEmail = new APIRest("email/Enviar");


            Email email = new Email()
            {
                Assunto = "Bem Vindo ao Vox Connections!",
                EmailDestinatario = usuario.Email,
                NomeDestinatario = usuario.Nome,
                Url = $"http://localhost:4200/create/{usuario.IdUsuario}"
            };


            JObject emailObject = JObject.FromObject(email);

            apiEmail.PostAsync($"/api/Email/Enviar", emailObject);

        }

        #endregion

    }
}
