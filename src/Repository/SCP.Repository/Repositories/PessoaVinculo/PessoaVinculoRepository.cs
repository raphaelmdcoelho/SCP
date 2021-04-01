using SCP.Domain.PessoaVinculo;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.PessoaVinculo
{
    public class PessoaVinculoRepository : BaseRepository<PessoaVinculoEntity>, IPessoaVinculoRepository
    {
        public PessoaVinculoRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}