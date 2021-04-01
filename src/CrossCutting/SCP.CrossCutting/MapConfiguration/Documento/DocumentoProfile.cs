using AutoMapper;
using SCP.CrossCutting.MapModels.Documento;
using SCP.Domain.Documento;

namespace SCP.CrossCutting.MapConfiguration.Documento
{
    public class DocumentoProfile : Profile
    {
        public DocumentoProfile()
        {
            CreateMap<DocumentoModel, DocumentoEntity>().ReverseMap();
        }
    }
}
