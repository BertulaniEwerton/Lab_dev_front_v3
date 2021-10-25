using AutoMapper;
using Solution.DataTransfer.Quebradas.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Quebradas.Entidades;

namespace Solution.Aplicacao.Quebradas.Profiles
{
    public class QuebradasProfile : Profile
    {
        public QuebradasProfile()
        {
            CreateMap<Quebrada, QuebradaResponse>();
            CreateMap<PaginacaoConsulta<Quebrada>, PaginacaoConsulta<QuebradaResponse>>();
        }
    }
}
