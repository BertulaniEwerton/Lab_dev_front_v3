using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Solution.Aplicacao.Faccoes.Servicos.Interfaces;
using Solution.DataTransfer.Faccoes.Requests;
using Solution.DataTransfer.Faccoes.Responses;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaccoesController : ControllerBase
    {
        private readonly IFaccoesAppServicos faccoesAppServicos;

        public FaccoesController(IFaccoesAppServicos faccoesAppServicos)
        {
            this.faccoesAppServicos = faccoesAppServicos;
        }

        /// <summary>
        ///     Recuperar Facção - Rota: https://localhost:44362/api/Faccoes/id
        /// </summary>
        /// <param name="id">id da Facção</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Recuperar(long? id)
        {
            if (!id.HasValue)
                return BadRequest();
            FaccaoResponse entidade = faccoesAppServicos.Recuperar(id.Value);
            if (entidade is null)
                return NotFound();
            return Ok(entidade);
        }

        /// <summary>
        ///     Listar Facções - Rota: https://localhost:44362/api/Faccoes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Listar([FromQuery] FaccaoListarRequest request)
        {
            return Ok(faccoesAppServicos.Listar(request));
        }

        /// <summary>
        ///     Inserir Facção - Rota: https://localhost:44362/api/Faccoes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Inserir([FromBody] FaccaoInserirRequest body)
        {
            return Ok(faccoesAppServicos.Inserir(body));
        }

        /// <summary>
        ///     Editar Facção - Rota: https://localhost:44362/api/Faccoes/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body">id da Facção</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(long id, [FromBody] FaccaoEditarRequest body)
        {
            return Ok(faccoesAppServicos.Editar(id, body));
        }

        /// <summary>
        ///     Deletar Facção - Rota: https://localhost:44362/api/Faccoes/id
        /// </summary>
        /// <param name="id">id da Facção</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Deletar(long id)
        {
            faccoesAppServicos.Deletar(id);
            return Ok();
        }
    }
}
