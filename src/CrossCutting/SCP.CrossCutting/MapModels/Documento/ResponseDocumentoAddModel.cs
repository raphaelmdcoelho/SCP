using SCP.CrossCutting.MapModels.Response;

namespace SCP.CrossCutting.MapModels.Documento
{
    public class ResponseDocumentoAddModel : ResponseModel
    {
        public DocumentoModel Documento { get; set; }
    }
}