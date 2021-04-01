using AutoMapper;
using SCP.CrossCutting.MapModels.Usuario;
using SCP.Repository.Repositories.Usuario;
using SCP.Repository.UoW;
using SCP.Services.Authentication;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UsuarioService(IUsuarioRepository usuarioRepository,
            IAuthService authService,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<UsuarioModel> Get(string username, string senha)
        {
            var usuarioEntityResult = await _usuarioRepository.GetAll();

            var usuarioEntity = usuarioEntityResult.Where(u => u.Username == username).FirstOrDefault();
            
            var hash = _authService.GetPasswordHash(senha);

            if(usuarioEntity != null && usuarioEntity.Senha != hash)
            {
                return null;
            }

            return _mapper.Map<UsuarioModel>(usuarioEntity);
        }
    }
}
