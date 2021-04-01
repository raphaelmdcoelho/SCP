using AutoMapper;
using SCP.CrossCutting.MapModels.Historico;
using SCP.Domain.Historico;

namespace SCP.CrossCutting.MapConfiguration.Historico
{
    public class HistoricoProfile : Profile
    {
        public HistoricoProfile()
        {
            CreateMap<HistoricoModel, HistoricoEntity>().ReverseMap();
        }
    }
}
