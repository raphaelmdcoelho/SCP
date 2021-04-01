using SCP.CrossCutting.MapModels.Documento;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCP.Services.Documento
{
    public interface IDocumentoService
    {
        Task<IEnumerable<DocumentoModel>> GetAll();
        Task<ResponseDocumentoAddModel> Add(DocumentoAddModel model);
        Task<ResponseDocumentoRemoveModel> Remove(int id);
        Task<DocumentoModel> Get(int id);
        void ConfigureDocumentoToAdd(DocumentoModel model);
    }
}
