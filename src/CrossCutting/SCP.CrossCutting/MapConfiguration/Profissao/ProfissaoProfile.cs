using AutoMapper;
using SCP.CrossCutting.MapModels.Profissao;
using SCP.Domain.Profissao;

namespace SCP.CrossCutting.MapConfiguration.Profissao
{
    public class ProfissaoProfile : Profile
    {
        public ProfissaoProfile()
        {
            CreateMap<ProfissaoModel, ProfissaoEntity>().ReverseMap();
        }
    }
}
