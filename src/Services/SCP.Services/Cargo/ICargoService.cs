using SCP.CrossCutting.MapModels.Cargo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCP.Services.Cargo
{
    public interface ICargoService
    {
        Task<IEnumerable<CargoModel>> GetAll();
        Task<int> Add(CargoModel model);
        Task<ResponseCargoRemoveModel> Remove(int id);
    }
}
