using SCP.Domain.Cargo;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Cargo
{
    public class CargoRepository : BaseRepository<CargoEntity>, ICargoRepository
    {
        public CargoRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}