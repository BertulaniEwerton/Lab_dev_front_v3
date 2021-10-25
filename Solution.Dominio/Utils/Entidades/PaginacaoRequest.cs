using Solution.Dominio.Utils.Enumeradores;

namespace Solution.Dominio.Utils
{
    public class PaginacaoRequest
    {
        public PaginacaoRequest(int pg, int qt, string cpOrd)
        {
            Pg = pg;
            Qt = qt;
            CpOrd = new string[1] { cpOrd };
        }

        public TipoOrdenacaoEnum TpOrd { get; set; }
        public string[] CpOrd { get; set; }
        public int Pg { get; set; }
        public int Qt { get; set; }
    }
}
