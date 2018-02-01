using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using VoxConnections.Convidados.Core;
using VoxConnections.Convidados.Application.Services;
using VoxConnections.Convidados.Application;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace VoxConnections.Convidados.WebApi.Controllers
{
    /// <summary>
    /// Controller para cadastro de Gestor
    /// </summary>
    public class GestorController : Controller
    {

        #region Atributos

        private readonly IGestorService _service;

        #endregion

        #region Construtor

        /// <summary>
        /// Implementação da Service
        /// </summary>
        /// <param name="service"></param>
        public GestorController(IGestorService service)
        {
            _service = service;
        }

        #endregion


        /// <summary>
        /// Cria um novo Gestor
        /// </summary>
        /// <param name="gestor"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Criar")]
        public IActionResult Criar([FromBody]JObject gestor)
        {
            //Verifica se os parametros foram informados
            if (gestor == null)
            {
                return BadRequest();
            }

            try
            {
                Gestor model = JsonConvert.DeserializeObject<Gestor>(Convert.ToString(gestor["gestor"]));
                var senha =  Convert.ToString(gestor["senha"]);

                _service.Gravar(model, null);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que finaliza o cadastro do Gestor
        /// </summary>
        /// <param name="gestor"></param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize("Admin")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [Route("api/[controller]/Alterar")]
        public IActionResult Alterar([FromBody]JObject gestor)
        {
            //Verifica se os parametros foram informados
            if (gestor == null)
            {
                return BadRequest();
            }

            try
            {

                Gestor model = JsonConvert.DeserializeObject<Gestor>(Convert.ToString(gestor));

                _service.Update(model);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que retorna o detalhe do Gestor
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
        /// Método que lista todos os Gestores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Admin")]
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