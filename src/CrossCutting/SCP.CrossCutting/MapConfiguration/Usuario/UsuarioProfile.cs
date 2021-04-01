using AutoMapper;
using SCP.CrossCutting.MapModels.Usuario;
using SCP.Domain.Usuario;

namespace SCP.CrossCutting.MapConfiguration.Usuario
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioModel, UsuarioEntity>().ReverseMap();
        }
    }
}
