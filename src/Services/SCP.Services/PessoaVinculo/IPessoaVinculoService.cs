using SCP.CrossCutting.MapModels.PessoaVinculo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCP.Services.PessoaVinculo
{
    public interface IPessoaVinculoService
    {
        Task<IEnumerable<PessoaVinculoModel>> GetAll();
        Task<ResponsePessoaVinculoAddModel> Add(PessoaVinculoAddModel model);
        Task<bool> Update(PessoaVinculoUpdateModel model);
        Task<ResponsePessoaVinculoRemoveModel> Remove(int id);
        Task<PessoaVinculoModel> Get(int id);
    }
}
