using System.Linq;

using Solution.DataTransfer.Utils;

namespace Solution.Dominio.Utils
{
    public static class RepositoriosExtension
    {
        public static PaginacaoConsulta<T> Paginar<T>(this IQueryable<T> query, PaginacaoRequest request)
        {
            return new PaginacaoConsulta<T>()
            {
                Total = query.Count(),
                Registros = query.Take(request.Qt)
                                 .Skip(request.Qt * (request.Pg - 1))
            };
            
        }
    }
}
