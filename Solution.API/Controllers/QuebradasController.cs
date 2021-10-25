using Microsoft.AspNetCore.Mvc;
using Solution.Aplicacao.Quebradas.Servicos.Interfaces;
using Solution.DataTransfer.Quebradas.Requests;
using Solution.DataTransfer.Quebradas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuebradasController : ControllerBase
    {
        private readonly IQuebradasAppServicos quebradaAppServicos;

        public QuebradasController(IQuebradasAppServicos quebradaAppServicos)
        {
            this.quebradaAppServicos = quebradaAppServicos;
        }

        /// <summary>
        ///     Recuperar Quebrada - Rota: https://localhost:44362/api/Quebradas/id
        /// </summary>
        /// <param name="id">id da Quebrada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Recuperar(long? id)
        {
            if (!id.HasValue)
                return BadRequest();
            QuebradaResponse entidade = quebradaAppServicos.Recuperar(id.Value);
            if (entidade is null)
                return NotFound();
            return Ok(entidade);
        }

        /// <summary>
        ///     Listar Quebradas - Rota: https://localhost:44362/api/Quebradas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Listar([FromQuery] QuebradaListarRequest request)
        {
            return Ok(quebradaAppServicos.Listar(request));
        }

        /// <summary>
        ///     Inserir Quebrada - Rota: https://localhost:44362/api/Quebradas
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Inserir([FromBody] QuebradaInserirRequest body)
        {
            return Ok(quebradaAppServicos.Inserir(body));
        }

        /// <summary>
        ///     Editar Quebrada - Rota: https://localhost:44362/api/Quebradas/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body">id da Quebrada</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(long id, [FromBody] QuebradaEditarRequest body)
        {
            return Ok(quebradaAppServicos.Editar(id, body));
        }

        /// <summary>
        ///     Deletar Quebrada - Rota: https://localhost:44362/api/Quebradas/id
        /// </summary>
        /// <param name="id">id da Quebrada</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Deletar(long id)
        {
            quebradaAppServicos.Deletar(id);
            return Ok();
        }

    }
}
