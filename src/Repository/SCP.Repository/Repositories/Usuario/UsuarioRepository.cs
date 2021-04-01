using SCP.Domain.Usuario;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Usuario
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}
