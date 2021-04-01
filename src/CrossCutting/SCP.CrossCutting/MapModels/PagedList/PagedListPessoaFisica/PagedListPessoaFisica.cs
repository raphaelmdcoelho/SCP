using SCP.CrossCutting.MapModels.PessoaFisica;

namespace SCP.CrossCutting.MapModels.PagedList.PagedListPessoaFisica
{
    public class PagedListPessoaFisica : PagedList
    {
        public PessoaFisicaFilter PessoaFisicaFilter { get; set; }
    }
}
