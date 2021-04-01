using AutoMapper;
using SCP.CrossCutting.MapModels.Localizacao.Endereco;
using SCP.Domain.Localizacao.Endereco;
using SCP.Repository.Repositories.Endereco;
using SCP.Repository.UoW;
using System.Threading.Tasks;

namespace SCP.Services.Localizacao.Endereco
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public EnderecoService(IEnderecoRepository enderecoRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Add(EnderecoModel model)
        {
            var entity = _mapper.Map<EnderecoEntity>(model);
            var enderecoEntityDbResult = await _enderecoRepository.Insert(entity);
            var enderecoEntityDb = (EnderecoEntity)enderecoEntityDbResult.Entity;

            _uow.SaveChanges();

            return enderecoEntityDb.Id;
        }
    }
}
