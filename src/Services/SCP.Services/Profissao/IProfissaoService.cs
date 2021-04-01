using SCP.CrossCutting.MapModels.Profissao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCP.Services.Profissao
{
    public interface IProfissaoService
    {
        Task<IEnumerable<ProfissaoModel>> GetAll();
        Task<int> Add(ProfissaoModel model);
        Task<ResponseProfissaoRemoveModel> Remove(int id);
    }
}
