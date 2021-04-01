using SCP.Domain.Localizacao.Endereco;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;

namespace SCP.Repository.Repositories.Endereco
{
    public class EnderecoRepository : BaseRepository<EnderecoEntity>, IEnderecoRepository
    {
        public EnderecoRepository(BaseContext baseContext) : base(baseContext)
        {

        }
    }
}
