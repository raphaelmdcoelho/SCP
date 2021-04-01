using SCP.Domain.PessoaJuridica;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.PessoaJuridica
{
    public class PessoaJuridicaRepository : BaseRepository<PessoaJuridicaEntity>, IPessoaJuridicaRepository
    {
        public PessoaJuridicaRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}
