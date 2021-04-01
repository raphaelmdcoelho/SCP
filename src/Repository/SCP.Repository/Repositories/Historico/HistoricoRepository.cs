using SCP.Domain.Historico;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Historico
{
    public class HistoricoRepository : BaseRepository<HistoricoEntity>, IHistoricoRepository
    {
        public HistoricoRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}