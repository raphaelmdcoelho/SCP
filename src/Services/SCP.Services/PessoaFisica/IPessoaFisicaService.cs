using SCP.CrossCutting.MapModels.PagedList.PagedListPessoaFisica;
using SCP.CrossCutting.MapModels.PessoaFisica;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCP.Services.PessoaFisica
{
    public interface IPessoaFisicaService
    {
        Task<IEnumerable<PessoaFisicaModel>> GetAll();
        Task<List<PessoaFisicaModel>> GetAllPagedList(PagedListPessoaFisica pagedListPessoaFisica);
        Task<ResponsePessoaFisicaAddModel> Add(PessoaFisicaAddModel model);
        Task<bool> Update(PessoaFisicaUpdateModel model);
        Task<ResponsePessoaFisicaRemoveModel> Remove(int id);
        Task<PessoaFisicaModel> Get(int id);
    }
}
