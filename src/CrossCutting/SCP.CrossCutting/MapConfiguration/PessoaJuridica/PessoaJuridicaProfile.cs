using AutoMapper;
using SCP.CrossCutting.MapModels.PessoaJuridica;
using SCP.Domain.PessoaJuridica;

namespace SCP.CrossCutting.MapConfiguration.PessoaJuridica
{
    public class PessoaJuridicaProfile : Profile
    {
        public PessoaJuridicaProfile()
        {
            CreateMap<PessoaJuridicaModel, PessoaJuridicaEntity>().ReverseMap();
            CreateMap<PessoaJuridicaAddModel, PessoaJuridicaEntity>().ReverseMap();
        }
    }
}
