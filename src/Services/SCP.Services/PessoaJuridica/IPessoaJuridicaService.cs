using SCP.CrossCutting.MapModels.PessoaJuridica;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCP.Services.PessoaJuridica
{
    public interface IPessoaJuridicaService
    {
        Task<IEnumerable<PessoaJuridicaModel>> GetAll();
        Task<ResponsePessoaJuridicaAddModel> Add(PessoaJuridicaAddModel model);
        Task<bool> Update(PessoaJuridicaUpdateModel model);
        Task<ResponsePessoaJuridicaRemoveModel> Remove(int id);
        Task<PessoaJuridicaModel> Get(int id);
    }
}
