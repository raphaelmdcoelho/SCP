using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCP.CrossCutting.MapModels.PessoaVinculo;
using SCP.Domain.PessoaVinculo;
using SCP.Repository.Repositories.PessoaVinculo;
using SCP.Repository.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Services.PessoaVinculo
{
    public class PessoaVinculoService : IPessoaVinculoService
    {
        private readonly IPessoaVinculoRepository _pessoaVinculoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PessoaVinculoService(IPessoaVinculoRepository pessoaVinculoRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _pessoaVinculoRepository = pessoaVinculoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ResponsePessoaVinculoAddModel> Add(PessoaVinculoAddModel model)
        {
            // TODO: Validation: (CPF e Id não podem ser repetidos)

            try
            {
                var pessoaVinculoEntity = _mapper.Map<PessoaVinculoEntity>(model);
                var pessoaVinculoEntityDb = await _pessoaVinculoRepository.Insert(pessoaVinculoEntity);

                _uow.SaveChanges();

                return new ResponsePessoaVinculoAddModel { PessoaVinculo = _mapper.Map<PessoaVinculoModel>((PessoaVinculoEntity)pessoaVinculoEntityDb.Entity), Message = "Vínculo Registrado com Sucesso", Success = true };
            }
            catch (Exception ex)
            {
                return new ResponsePessoaVinculoAddModel { PessoaVinculo = null, Message = ex.Message, Success = false };
            }
        }

        public async Task<ResponsePessoaVinculoRemoveModel> Remove(int id)
        {
            try
            {
                var entityResult = await _pessoaVinculoRepository.GetAll();
                var entity = entityResult.Where(pf => pf.Id == id).FirstOrDefault();

                if (entity != null)
                {
                    _pessoaVinculoRepository.Delete(entity.Id);
                    _uow.SaveChanges();

                    return new ResponsePessoaVinculoRemoveModel { Success = true, Message = "Vínculo removido com sucesso" };
                }

                return new ResponsePessoaVinculoRemoveModel { Success = false, Message = "Vínculo não existe" };
            }
            catch (Exception)
            {
                return new ResponsePessoaVinculoRemoveModel { Success = true, Message = "Ocorreu um erro ao remover o vínculo" };
            }
        }

        public async Task<bool> Update(PessoaVinculoUpdateModel model)
        {
            try
            {
                var entityDb = await _pessoaVinculoRepository.GetById(model.Id);
                var entity = UpdateEntity(entityDb, model);

                _pessoaVinculoRepository.Update(entity);
                _uow.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private PessoaVinculoEntity UpdateEntity(PessoaVinculoEntity entity, PessoaVinculoUpdateModel model)
        {
            entity.Id = model.Id;
            entity.PessoaFisicaId = model.PessoaFisicaId;
            entity.PessoaJuridicaId = model.PessoaFisicaId;
            entity.TipoVinculo = model.TipoVinculo;
            entity.DthRegistro = model.DthRegistro;
            entity.DthExclusao = model.DthExclusao;
            entity.IsAtivo = model.IsAtivo;    

            return entity;
        }

        public async Task<IEnumerable<PessoaVinculoModel>> GetAll()
        {
            var query = await _pessoaVinculoRepository
                .GetAll();

            return query.AsQueryable()
                .Include("PessoaFisica")
                .Include("PessoaJuridica")
                .Select(x => _mapper.Map<PessoaVinculoModel>(x));
        }

        public async Task<PessoaVinculoModel> Get(int id)
        {
            // O include só é possível em cima de uma retorno do tipo IQueryable (Coleção):

            var query = await _pessoaVinculoRepository
                .GetAll();

            return query.Include("PessoaFisica")
                .Include("PessoaJuridica")
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<PessoaVinculoModel>(x))
                .FirstOrDefault();
        }
    }
}
