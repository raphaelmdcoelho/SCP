using AutoMapper;
using SCP.CrossCutting.MapModels.Profissao;
using SCP.Domain.Profissao;
using SCP.Repository.Repositories.Profissao;
using SCP.Repository.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Services.Profissao
{
    public class ProfissaoService : IProfissaoService
    {
        private readonly IProfissaoRepository _profissaoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ProfissaoService(IProfissaoRepository profissaoRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _profissaoRepository = profissaoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Add(ProfissaoModel model)
        {
            var entity = _mapper.Map<ProfissaoEntity>(model);
            var entityDbResult = await _profissaoRepository.Insert(entity);
            var entityDb = (ProfissaoEntity)entityDbResult.Entity;
            _uow.SaveChanges();
            return entityDb.Id;
        }

        public async Task<IEnumerable<ProfissaoModel>> GetAll()
        {
            var result = await _profissaoRepository.GetAll();
            return result.Select(x => _mapper.Map<ProfissaoModel>(x));
        }

        public async Task<ResponseProfissaoRemoveModel> Remove(int id)
        {
            try
            {
                var entityResult = await _profissaoRepository.GetAll();
                var entity = entityResult.Where(pf => pf.Id == id).FirstOrDefault();

                if (entity != null)
                {
                    _profissaoRepository.Delete(entity.Id);
                    _uow.SaveChanges();

                    return new ResponseProfissaoRemoveModel { Success = true, Message = "Profissão removido com sucesso" };
                }

                return new ResponseProfissaoRemoveModel { Success = false, Message = "Profissão não existe" };
            }
            catch (Exception)
            {
                return new ResponseProfissaoRemoveModel { Success = true, Message = "Ocorreu um erro ao remover a profissão" };
            }
        }
    }
}
