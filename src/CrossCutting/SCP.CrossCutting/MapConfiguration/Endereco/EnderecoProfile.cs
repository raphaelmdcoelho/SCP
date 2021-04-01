using AutoMapper;
using SCP.CrossCutting.MapModels.Localizacao.Endereco;
using SCP.Domain.Localizacao.Endereco;

namespace SCP.CrossCutting.MapConfiguration.Endereco
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoModel, EnderecoEntity>().ReverseMap();
        }
    }
}
