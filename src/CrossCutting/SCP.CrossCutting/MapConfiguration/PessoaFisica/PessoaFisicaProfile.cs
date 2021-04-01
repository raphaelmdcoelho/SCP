using AutoMapper;
using SCP.CrossCutting.MapModels.PessoaFisica;
using SCP.Domain.PessoaFisica;

namespace SCP.CrossCutting.MapConfiguration.PessoaFisica
{
    public class PessoaFisicaProfile : Profile
    {
        public PessoaFisicaProfile()
        {
            CreateMap<PessoaFisicaModel, PessoaFisicaEntity>().ReverseMap();
            CreateMap<PessoaFisicaAddModel, PessoaFisicaEntity>().ReverseMap();
        }
    }
}
