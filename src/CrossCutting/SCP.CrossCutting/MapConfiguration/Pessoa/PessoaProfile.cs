using AutoMapper;
using SCP.CrossCutting.MapModels.Pessoa;
using SCP.Domain.Pessoa;

namespace SCP.CrossCutting.MapConfiguration.Pessoa
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, PessoaEntity>().ReverseMap();
        }
    }
}
