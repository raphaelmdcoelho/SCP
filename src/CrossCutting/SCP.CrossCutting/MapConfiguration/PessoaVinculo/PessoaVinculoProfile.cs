using AutoMapper;
using SCP.CrossCutting.MapModels.PessoaVinculo;
using SCP.Domain.PessoaVinculo;

namespace SCP.CrossCutting.MapConfiguration.PessoaVinculo
{
    public class PessoaVinculoProfile : Profile
    {
        public PessoaVinculoProfile()
        {
            CreateMap<PessoaVinculoModel, PessoaVinculoEntity>().ReverseMap();
            CreateMap<PessoaVinculoAddModel, PessoaVinculoEntity>().ReverseMap();
        }
    }
}
