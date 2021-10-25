using AutoMapper;
using Solution.DataTransfer.Localizacoes.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Localizacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Aplicacao.Localizacoes.Profiles
{
    public class LocalizacoesProfile : Profile
    {
        public LocalizacoesProfile()
        {
            CreateMap<Localizacao, LocalizacaoResponse>();
            CreateMap<PaginacaoConsulta<Localizacao>, PaginacaoConsulta<LocalizacaoResponse>>();
        }
    }
}
