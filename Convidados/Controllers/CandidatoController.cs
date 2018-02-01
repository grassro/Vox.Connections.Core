using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Convidados.Controllers
{
    /// <summary>
    /// Controller para cadastro de Candidato
    /// </summary>
    public class CandidatoController : Controller
    {

        #region Atributos

        //private readonly CandidatoBusiness _business;
        private readonly ICandidatoService _service;

        #endregion

        #region Construtor

        /// <summary>
        /// Implementação da Service
        /// </summary>
        /// <param name="service"></param>
        public CandidatoController(ICandidatoService service)
        {
            _service = service;
        }

        #endregion


        /// <summary>
        /// Cria um novo Candidato
        /// </summary>
        /// <param name="candidato"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Criar")]
        public IActionResult Criar([FromBody]JObject candidato)
        {
            //Verifica se os parametros foram informados
            if (candidato == null)
            {
                return BadRequest();
            }

            try
            {
                Candidato model = JsonConvert.DeserializeObject<Candidato>(Convert.ToString(candidato["candidato"]));
                var senha = JsonConvert.DeserializeObject<string>(Convert.ToString(candidato["senha"]));

                _service.Gravar(model, senha);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método que finaliza o cadastro do Candidato
        /// </summary>
        /// <param name="candidato"></param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize("Candidato")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Alterar")]
        public IActionResult Alterar([FromBody]JObject candidato)
        {
            //Verifica se os parametros foram informados
            if (candidato == null)
            {
                return BadRequest();
            }

            try
            {

                Candidato model = JsonConvert.DeserializeObject<Candidato>(Convert.ToString(candidato["candidato"]));

                _service.Alterar(model);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que retorna o detalhe do candidato
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Consultar/{id}")]
        public IActionResult Detalhe(int id)
        {
            //Verifica se os parametros foram informados
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var candidato = _service.Detalhe(id);

                return Ok(candidato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método que lista todos os Candidatos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Listar")]
        public IActionResult Listar()
        {
            try
            {
                var listResult = _service.Listar();

                return Ok(listResult);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Método que busca todos os Candidatos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Buscar")]
        public IActionResult Buscar([FromBody]JObject candidato)
        {
            try
            {

                CandidatoBusca model = JsonConvert.DeserializeObject<CandidatoBusca>(Convert.ToString(candidato["candidatoBusca"]));

                var listResult = _service.Buscar(model);

                return Ok(listResult);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
