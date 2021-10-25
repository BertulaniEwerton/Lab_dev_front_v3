using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Solution.Aplicacao.Investigacoes.Servicos.Interfaces;
using Solution.DataTransfer.Investigacoes.Requests;
using Solution.DataTransfer.Investigacoes.Responses;

namespace Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestigacoesController : ControllerBase
    {
        private readonly IInvestigacoesAppServico investigacoesAppServico;

        public InvestigacoesController(IInvestigacoesAppServico investigacoesAppServico)
        {
            this.investigacoesAppServico = investigacoesAppServico;
        }

        /// <summary>
        ///     Recuperar investigacao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult Recuperar(long? id)
        //{
        //    if (!id.HasValue)
        //        return BadRequest();
        //    InvestigaoResponse entidade = investigacoesAppServico.Recuperar(id.Value);
        //    if (entidade is null)
        //        return NotFound();
        //    return Ok(entidade);
        //}

        /// <summary>
        ///     Listar investigacoes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpGet]
        //public IActionResult Listar([FromQuery] InvestigacaoListarRequest request)
        //{
        //    return Ok(investigacoesAppServico.Listar(request));
        //}

        /// <summary>
        ///     Inserir na investigacao para um membro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult Inserir([FromBody] InvestigacaoInserirRequest body)
        //{
        //    return Ok(investigacoesAppServico.Inserir(body));
        //}

        /// <summary>
        ///     Edita a investigacao
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult Editar(long id, [FromBody] InvestigacaoEditarRequest body)
        //{
        //    return Ok(investigacoesAppServico.Editar(id, body));
        //}

        /// <summary>
        ///     Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpDelete]
        //[Route("{id}")]
        //public IActionResult Deletar(long id)
        //{
        //    investigacoesAppServico.Deletar(id);
        //    return Ok();
        //}
    }
}
