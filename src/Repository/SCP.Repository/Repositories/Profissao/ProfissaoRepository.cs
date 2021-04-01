using SCP.Domain.Profissao;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Profissao
{
    public class ProfissaoRepository : BaseRepository<ProfissaoEntity>, IProfissaoRepository
    {
        public ProfissaoRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}
