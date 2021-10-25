using AutoMapper;

using Solution.DataTransfer.Investigacoes.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Investigacoes.Entidades;

namespace Solution.Aplicacao.Investigacoes.Profiles
{
    public class InvestigacoesProfile : Profile
    {
        public InvestigacoesProfile()
        {
            CreateMap<Investigacao, InvestigaoResponse>();
            CreateMap<PaginacaoConsulta<Investigacao>, PaginacaoConsulta<InvestigaoResponse>>();
        }
    }
}
