using AutoMapper;
using SCP.CrossCutting.MapModels.Cargo;
using SCP.Domain.Cargo;

namespace SCP.CrossCutting.MapConfiguration.Cargo
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<CargoModel, CargoEntity>().ReverseMap();
        }
    }
}
