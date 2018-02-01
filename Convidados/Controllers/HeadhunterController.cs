using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using VoxConnections.Convidados.Application;
using VoxConnections.Convidados.Core;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace VoxConnections.Convidados.WebApi.Controllers
{

    /// <summary>
    /// Controller para cadastro de Headhunter
    /// </summary>
    /// 
    //[ValidateModel]
    [Produces("application/json")]
    public class HeadhunterController : Controller
    {
        #region Atributos

        private readonly IHeadhunterService _service;

        #endregion

        #region Construtor

        /// <summary>
        /// Implementação da Service
        /// </summary>
        /// <param name="service"></param>
        public HeadhunterController(IHeadhunterService service)
        {
            _service = service;
        }

        #endregion


        /// <summary>
        /// Cria um novo Headhunter
        /// </summary>
        /// <param name="headhunter"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[Controller]/Criar")]
        public IActionResult Criar([FromBody]JObject headhunter)
        {
            //Verifica se os parametros foram informados
            if (headhunter == null)
            {
                return BadRequest();
            }

            try
            {

                Headhunter model = JsonConvert.DeserializeObject<Headhunter>(Convert.ToString(headhunter["headhunter"]));
                var senha = JsonConvert.DeserializeObject<string>(Convert.ToString(headhunter["senha"]));

                _service.Gravar(model, senha);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que finaliza o cadastro do Headhunter
        /// </summary>
        /// <param name="headhunter"></param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize("Headhunter")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Alterar")]
        public IActionResult Alterar([FromBody]Headhunter headhunter)
        {
            //Verifica se os parametros foram informados
            if (headhunter == null)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(headhunter);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que retorna o detalhe do Headhunter
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
        /// Método que lista todos os Headhunters
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
    }
}