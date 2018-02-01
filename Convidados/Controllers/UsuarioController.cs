using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Core;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Convidados.Controllers
{
    /// <summary>
    /// Controller para cadastro de Candidato
    /// </summary>
    public class UsuarioController : Controller
    {

        #region Atributos

        private readonly IUsuarioService _service;

        #endregion

        #region Construtor

        /// <summary>
        /// Implementação da Service
        /// </summary>
        /// <param name="service"></param>
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        #endregion

        /// <summary>
        /// Cria Usuario e envia email
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Criar")]
        public IActionResult Criar([FromBody]List<Usuario> usuarios)
        {
            //Verifica se os parametros foram informados
            if (usuarios == null)
            {
                return BadRequest();
            }

            try
            {

                _service.InsereUsuarios(usuarios);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que retorna o Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [SwaggerResponse(407)]
        [Route("api/[controller]/Buscar/{idUsuario}")]
        public IActionResult Buscar(string idUsuario)
        {

            var sw = Stopwatch.StartNew();

            try
            {
                var result =  _service.Buscar(idUsuario);

                //Verifica se houve retorno 
                if (result.IdUsuario != null)
                {
                    sw.Stop();

                    return Ok(result);
                }
                else
                {
                    sw.Stop();

                    return StatusCode(407);
                }
            }
            catch (Exception ex)
            {
                //Instrumentar AppInsights
                sw.Stop();
                var telemetry = new TelemetryClient();

                var properties = new Dictionary<string, string>
                    {
                        { "Controller", "UsuarioController" },
                        { "Method", "Buscar" },
                        { "Parameters", idUsuario.ToString() }
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



    }
}
