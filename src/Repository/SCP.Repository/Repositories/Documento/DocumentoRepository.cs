using SCP.Domain.Documento;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Documento
{
    public class DocumentoRepository : BaseRepository<DocumentoEntity>, IDocumentoRepository
    {
        public DocumentoRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}
