using AutoMapper;
using SCP.CrossCutting.MapModels.Cargo;
using SCP.Domain.Cargo;
using SCP.Repository.Repositories.Cargo;
using SCP.Repository.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Services.Cargo
{
    public class CargoService : ICargoService
    {
        //private readonly IBaseRepository<CargoEntity> _baseRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CargoService(ICargoRepository cargoRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<int> Add(CargoModel model)
        {
            var entity = _mapper.Map<CargoEntity>(model);
            var entityDb = await (Task<CargoEntity>)_cargoRepository.Insert(entity).Result.Entity;
            _uow.SaveChanges();
            return entityDb.Id;
        }

        public async Task<IEnumerable<CargoModel>> GetAll()
        {
            var list = await _cargoRepository.GetAll();
            return list.Select(x => _mapper.Map<CargoModel>(x));
        }

        public async Task<ResponseCargoRemoveModel> Remove(int id)
        {
            try
            {
                var entityResult = await _cargoRepository.GetAll();
                var entity = entityResult.Where(pf => pf.Id == id).FirstOrDefault();

                if (entity != null)
                {
                    _cargoRepository.Delete(entity.Id);
                    _uow.SaveChanges();

                    return new ResponseCargoRemoveModel { Success = true, Message = "Pessoa removido com sucesso" };
                }

                return new ResponseCargoRemoveModel { Success = false, Message = "Pessoa não existe" };
            }
            catch (Exception)
            {
                return new ResponseCargoRemoveModel { Success = true, Message = "Ocorreu um erro ao remover a pessoa" };
            }
        }
    }
}
