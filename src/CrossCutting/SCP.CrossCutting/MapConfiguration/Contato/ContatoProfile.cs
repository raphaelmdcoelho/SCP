using AutoMapper;
using SCP.CrossCutting.MapModels.Contato;
using SCP.Domain.Contato;

namespace SCP.CrossCutting.MapConfiguration.Contato
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<ContatoModel, ContatoEntity>().ReverseMap();
        }
    }
}
