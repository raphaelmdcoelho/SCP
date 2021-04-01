using AutoMapper;
using SCP.CrossCutting.MapModels.ProfissaoVinculo;
using SCP.Domain.ProfissaoVinculo;

namespace SCP.CrossCutting.MapConfiguration.ProfissaoVinculo
{
    public class ProfissaoVinculoProfile : Profile
    {
        public ProfissaoVinculoProfile()
        {
            CreateMap<ProfissaoVinculoModel, ProfissaoVinculoEntity>().ReverseMap();
        }
    }
}
