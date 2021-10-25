using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Solution.DataTransfer.Membros.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Membros.Entidades;

namespace Solution.Aplicacao.Membros.Profiles
{
    public class MembrosProfile : Profile
    {
        public MembrosProfile()
        {
            CreateMap<Membro, MembroResponse>();
            CreateMap<PaginacaoConsulta<Membro>, PaginacaoConsulta<MembroResponse>>();
        }
    }
}
