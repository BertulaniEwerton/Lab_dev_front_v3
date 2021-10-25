using System.Collections.Generic;

namespace Solution.DataTransfer.Utils
{
    public class PaginacaoConsulta<T>
    {
        public long Total { get; set; }
        public IEnumerable<T> Registros { get; set; }
    }
}
