using AutoMapper;
using SCP.CrossCutting.MapModels.Historico;
using SCP.Domain.Historico;
using SCP.Repository.Repositories.Historico;
using SCP.Repository.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Services.Historico
{
    public class HistoricoService : IHistoricoService
    {
        private readonly IHistoricoRepository _historicoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public HistoricoService(IHistoricoRepository historicoRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _historicoRepository = historicoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ResponseHistoricoAddModel> Add(HistoricoAddModel model)
        {
            // TODO: Validation: (CPF e Id não podem ser repetidos)

            try
            {
                var historicoEntity = _mapper.Map<HistoricoEntity>(model);

                var historicoEntityDb = await _historicoRepository.Insert(historicoEntity);

                _uow.SaveChanges();

                return new ResponseHistoricoAddModel { Historico = _mapper.Map<HistoricoModel>((HistoricoEntity)historicoEntityDb.Entity), Message = "Historico Registrada com Sucesso", Success = true };
            }
            catch (Exception ex)
            {
                return new ResponseHistoricoAddModel { Historico = null, Message = ex.Message, Success = false };
            }
        }

        public async Task<IEnumerable<HistoricoModel>> GetAll()
        {
            var query = await _historicoRepository
                .GetAll();

            return query.AsQueryable()
                .Select(x => _mapper.Map<HistoricoModel>(x));
        }
    }
}
