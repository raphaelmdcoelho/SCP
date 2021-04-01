using SCP.Domain.Contato;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Contato
{
    public class ContatoRepository : BaseRepository<ContatoEntity>, IContatoRepository
    {
        public ContatoRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}
