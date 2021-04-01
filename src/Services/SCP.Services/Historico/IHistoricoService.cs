using SCP.CrossCutting.MapModels.Historico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCP.Services.Historico
{
    public interface IHistoricoService
    {
        Task<IEnumerable<HistoricoModel>> GetAll();
        Task<ResponseHistoricoAddModel> Add(HistoricoAddModel model);
    }
}
