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
    public class VagasCandidaturaService : BaseService<VagasCandidatura>, IVagasCandidaturaService
    {

        #region Atributos

        private readonly IVagasCandidaturaRepository _repository;
        private readonly IVagasRepository _repositoryVagas;
        private readonly IUsuarioRepository _repositoryUsuario;
        private readonly ICandidatoRepository _repositoryCandidato;
        private readonly IGestorRepository _repositoryGestor;
        private readonly IHeadhunterRepository _repositoryHeadhunter;

        #endregion

        #region Construtor

        public VagasCandidaturaService(IBaseRepository<VagasCandidatura> baseRepository, IVagasCandidaturaRepository repository, IVagasRepository repositoryVagas,
            IUsuarioRepository repositoryUsuario, ICandidatoRepository repositoryCandidato, IGestorRepository repositoryGestor, IHeadhunterRepository repositoryHeadhunter)
            : base(baseRepository)
        {
            _repository = repository;
            _repositoryVagas = repositoryVagas;
            _repositoryUsuario = repositoryUsuario;
            _repositoryCandidato = repositoryCandidato;
            _repositoryGestor = repositoryGestor;
            _repositoryHeadhunter = repositoryHeadhunter;
        }

        #endregion

        #region Métodos Públicos

        public async Task Candidatar(VagasCandidatura candidatura)
        {

            try
            {
                var vaga = _repositoryVagas.GetById(candidatura.IdVaga);
                var headhunter = _repositoryHeadhunter.GetById(vaga.IdHeadhunter);
                var usuarioHead = _repositoryUsuario.Buscar(headhunter.IdUsuario.ToString());
                var usuarioCandidato = _repositoryUsuario.Buscar(candidatura.IdUsuario);

                _repository.Add(candidatura);

                await EnviarEmailCandidato(usuarioCandidato, vaga);
                await EnviarEmailHeadhunter(usuarioHead, vaga, usuarioCandidato);


            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion Métodos Públicos

        #region Métodos Privados

        private async Task EnviarEmailCandidato(Usuario usuario, Vagas vaga)
        {
            APIRest apiEmail = new APIRest("email/Enviar");

            EmailCandidato email = new EmailCandidato()
            {
                Assunto = $"´Vox Connections - {vaga.Titulo}",
                EmailDestinatario = usuario.Email,
                NomeDestinatario = usuario.Nome,
                TituloVaga = vaga.Titulo
            };


            JObject emailObject = JObject.FromObject(email);

            await apiEmail.PostAsync($"/api/Email/EnviarCandidato", emailObject);

        }

        private async Task EnviarEmailHeadhunter(Usuario usuario, Vagas vagas, Usuario candidato)
        {
            APIRest apiEmail = new APIRest("email/Enviar");

            EmailHeadhunter email = new EmailHeadhunter()
            {
                Assunto = $"´Vox Connections - {vagas.Titulo}",
                EmailDestinatario = usuario.Email,
                NomeDestinatario = usuario.Nome,
                NomeCandidato = candidato.Nome,
                EmailCandidato = candidato.Email,
                TituloVaga = vagas.Titulo,
                Url = $"http://localhost:4200/get/{candidato.IdUsuario}"
            };


            JObject emailObject = JObject.FromObject(email);

            await apiEmail.PostAsync($"/api/Email/EnviarHeadhunter", emailObject);

        }

        #endregion

    }
}
