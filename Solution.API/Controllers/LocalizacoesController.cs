using Microsoft.AspNetCore.Mvc;
using Solution.Aplicacao.Localizacoes.Servicos.Interfaces;
using Solution.DataTransfer.Localizacoes.Requests;
using Solution.DataTransfer.Localizacoes.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacoesController : ControllerBase
    {
        private readonly ILocalizacoesAppServicos localizacoesAppServicos;

        public LocalizacoesController(ILocalizacoesAppServicos localizacoesAppServicos)
        {
            this.localizacoesAppServicos = localizacoesAppServicos;
        }

        /// <summary>
        ///     Recuperar Localizaçao - Rota: https://localhost:44362/api/Localizacoes/id
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
            LocalizacaoResponse entidade = localizacoesAppServicos.Recuperar(id.Value);
            if (entidade is null)
                return NotFound();
            return Ok(entidade);
        }


        /// <summary>
        ///     Listar Localizações - Rota: https://localhost:44362/api/Localizacoes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Listar([FromQuery] LocalizacaoListarRequest request)
        {
            return Ok(localizacoesAppServicos.Listar(request));
        }

        /// <summary>
        ///     Inserir Localizacao - Rota: https://localhost:44362/api/Localizacoes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Inserir([FromBody] LocalizacaoInserirRequest body)
        {
            return Ok(localizacoesAppServicos.Inserir(body));
        }

        /// <summary>
        ///     Editar Localizacao - Rota: https://localhost:44362/api/Membros/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body">id da Localizacao</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(long id, [FromBody] LocalizacaoEditarRequest body)
        {
            return Ok(localizacoesAppServicos.Editar(id, body));
        }



    }
}
