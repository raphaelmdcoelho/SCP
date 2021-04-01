using SCP.Domain.Pessoa;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Pessoa
{
    public class PessoaRepository : BaseRepository<PessoaEntity>, IPessoaRepository
    {
        public PessoaRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}
