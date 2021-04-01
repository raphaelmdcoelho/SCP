using SCP.Domain.Midia;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Midia
{
    public class MidiaRepository : BaseRepository<MidiaEntity>, IMidiaRepository
    {
        public MidiaRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}
