using Microsoft.AspNetCore.Mvc;
using Solution.Aplicacao.Membros.Interfaces;
using Solution.DataTransfer.Membros.Requests;
using Solution.DataTransfer.Membros.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembrosController : ControllerBase
    {
        private readonly IMembrosAppServicos membrosAppServicos;

        public MembrosController(IMembrosAppServicos membrosAppServicos)
        {
            this.membrosAppServicos = membrosAppServicos;
        }


        /// <summary>
        ///     Recuperar Membro - Rota: https://localhost:44362/api/Membros/id
        /// </summary>
        /// <param name="id">id do Membro</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Recuperar(long? id)
        {
            if (!id.HasValue)
                return BadRequest();
            MembroResponse entidade = membrosAppServicos.Recuperar(id.Value);
            if (entidade is null)
                return NotFound();
            return Ok(entidade);
        }

        /// <summary>
        ///     Listar Membros - Rota: https://localhost:44362/api/Membros
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Listar([FromQuery] MembroListarRequest request)
        {
            return Ok(membrosAppServicos.Listar(request));
        }

        /// <summary>
        ///     Inserir Membro - Rota: https://localhost:44362/api/Membros
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Inserir([FromBody] MembroInserirRequest body)
        {
            return Ok(membrosAppServicos.Inserir(body));
        }


        /// <summary>
        ///     Editar Membro - Rota: https://localhost:44362/api/Membros/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body">id da Membro</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(long id, [FromBody] MembroEditarRequest body)
        {
            return Ok(membrosAppServicos.Editar(id, body));
        }

        /// <summary>
        ///     Deletar Membro - Rota: https://localhost:44362/api/Membros/id
        /// </summary>
        /// <param name="id">id da Facção</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Deletar(long id)
        {
            membrosAppServicos.Deletar(id);
            return Ok();
        }

    }
}
