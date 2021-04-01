using AutoMapper;
using SCP.CrossCutting.MapModels.Midia;
using SCP.Domain.Midia;

namespace SCP.CrossCutting.MapConfiguration.Midia
{
    public class MidiaProfile : Profile
    {
        public MidiaProfile()
        {
            CreateMap<MidiaModel, MidiaEntity>().ReverseMap();
        }
    }
}
