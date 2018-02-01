using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Application;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace VoxConnections.Oportunidades.WebApi.Controllers
{
    /// <summary>
    /// Controller para cadastro de Vagas
    /// </summary>
    [EnableCors("AllowAllOrigins")]
    public class VagasController : Controller
    {

        #region Atributos

        private readonly IVagasService _service;
        private readonly IVagasCandidaturaService _serviceCandidatura;

        #endregion

        #region Construtor

        /// <summary>
        /// Implementação da Service
        /// </summary>
        /// <param name="service"></param>
        /// <param name="serviceCandidatura"></param>
        public VagasController(IVagasService service, IVagasCandidaturaService serviceCandidatura)
        {
            _service = service;
            _serviceCandidatura = serviceCandidatura;
        }

        #endregion

        /// <summary>
        /// Cria Vagas
        /// </summary>
        /// <param name="vaga"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Criar")]
        public IActionResult Criar([FromBody]JObject vaga)
        {
            //Verifica se os parametros foram informados
            if (vaga == null)
            {
                return BadRequest();
            }

            try
            {

                Vagas model = JsonConvert.DeserializeObject<Vagas>(Convert.ToString(vaga["vaga"]));

                _service.Salvar(model);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que retorna as Vagas
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Buscar")]
        public IActionResult Buscar([FromBody]JObject vaga)
        {

            var sw = Stopwatch.StartNew();

            //Verifica se os parametros foram informados
            if (vaga == null)
            {
                return BadRequest();
            }


            try
            {

                VagasBusca busca = JsonConvert.DeserializeObject<VagasBusca>(Convert.ToString(vaga["vagas"]));

                var result = _service.Buscar(busca);

                return Ok(result);

            }
            catch (Exception ex)
            {
                //Instrumentar AppInsights
                sw.Stop();
                var telemetry = new TelemetryClient();

                var properties = new Dictionary<string, string>
                    {
                        { "Controller", "VagasController" },
                        { "Method", "Buscar" },
                        { "Parameters", vaga.ToString() }
                    };

                var measurements = new Dictionary<string, double>
                    {
                        { "ExecutionTime", sw.ElapsedMilliseconds}
                    };

                telemetry.TrackException(ex, properties, measurements);

                //Retorna Internal Server Error
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Método que retorna o detalhe da Vaga
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
        /// Método que lista todas as Vagas da Timelime
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

                var listResult = _service.GetAll();

                return Ok(listResult);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Método que lista todas as Vagas da Timelime
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize("Admin")]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Timeline/{idUsuario}")]
        public IActionResult Timeline(string idUsuario)
        {
            try
            {

                var listResult = _service.Listar(idUsuario);

                return Ok(listResult);
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
        [HttpPost]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Candidatar")]
        public IActionResult Candidatar([FromBody]VagasCandidatura candidatura)
        {
            try
            {
                _serviceCandidatura.Candidatar(candidatura);

                return Ok();
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
        [HttpPut]
        [Authorize]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Encerrar/{idVaga}")]
        public IActionResult Encerrar(int idVaga)
        {
            try
            {
                _service.Encerrar(idVaga);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}

