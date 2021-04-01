using SCP.Domain.PessoaFisica;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.PessoaFisica
{
    public class PessoaFisicaRepository : BaseRepository<PessoaFisicaEntity>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}