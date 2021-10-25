using Solution.DataTransfer.Investigacoes.Requests;
using Solution.DataTransfer.Investigacoes.Responses;
using Solution.DataTransfer.Utils;

namespace Solution.Aplicacao.Investigacoes.Servicos.Interfaces
{
    public interface IInvestigacoesAppServico
    {
        InvestigaoResponse Recuperar(long id);
        PaginacaoConsulta<InvestigaoResponse> Listar(InvestigacaoListarRequest request);
        InvestigaoResponse Inserir(InvestigacaoInserirRequest request);
        InvestigaoResponse Editar(long id, InvestigacaoEditarRequest request);
        void Deletar(long id);
    }
}
