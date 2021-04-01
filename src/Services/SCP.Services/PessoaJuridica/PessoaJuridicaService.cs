using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCP.CrossCutting.MapModels.PessoaJuridica;
using SCP.Domain.Pessoa;
using SCP.Domain.PessoaJuridica;
using SCP.Domain.PessoaVinculo;
using SCP.Repository.Repositories.PessoaJuridica;
using SCP.Repository.UoW;
using SCP.Services.Documento;
using SCP.Services.Localizacao.Endereco;
using SCP.Services.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Services.PessoaJuridica
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly IPessoaService _pessoaService;
        private readonly IEnderecoService _enderecoService;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly IDocumentoService _documentoService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PessoaJuridicaService(IPessoaService pessoaService,
            IEnderecoService enderecoService,
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            IDocumentoService documentoService,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _pessoaService = pessoaService;
            _enderecoService = enderecoService;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _documentoService = documentoService;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ResponsePessoaJuridicaAddModel> Add(PessoaJuridicaAddModel model)
        {
            // TODO: Validation: (CPF e Id não podem ser repetidos)

            try
            {
                _pessoaService.ConfigurePessoaToAdd(model.Pessoa);

                var pessoaJuridicaEntity = _mapper.Map<PessoaJuridicaEntity>(model);

                var pessoaJuridicaEntityDbResult = await _pessoaJuridicaRepository.Insert(pessoaJuridicaEntity);
                var pessoaJuridicaEntityDb = (PessoaJuridicaEntity)pessoaJuridicaEntityDbResult.Entity;

                _uow.SaveChanges();

                return new ResponsePessoaJuridicaAddModel { PessoaJuridica = _mapper.Map<PessoaJuridicaModel>(pessoaJuridicaEntityDb), Message = "Pessoa Jurídica Registrada com Sucesso", Success = true };
            }
            catch (Exception ex)
            {
                return new ResponsePessoaJuridicaAddModel { PessoaJuridica = null, Message = ex.Message, Success = false };
            }
        }

        public async Task<ResponsePessoaJuridicaRemoveModel> Remove(int id)
        {
            try
            {
                var entityResult = await _pessoaJuridicaRepository.GetAll();
                var entity = entityResult.Where(pf => pf.Id == id).FirstOrDefault();

                if (entity != null)
                {
                    _pessoaJuridicaRepository.Delete(entity.Id);
                    _uow.SaveChanges();

                    return new ResponsePessoaJuridicaRemoveModel { Success = true, Message = "Pessoa jurídica removida com sucesso" };
                }

                return new ResponsePessoaJuridicaRemoveModel { Success = false, Message = "Pessoa jurídica não existe" };
            }
            catch (Exception)
            {
                return new ResponsePessoaJuridicaRemoveModel { Success = true, Message = "Ocorreu um erro ao remover a pessoa jurídica" };
            }
        }

        public async Task<bool> Update(PessoaJuridicaUpdateModel model)
        {
            try
            {
                var entityDb = await _pessoaJuridicaRepository.GetById(model.Id);
                var entity = UpdateEntity(entityDb, model);

                _pessoaJuridicaRepository.Update(entity);
                _uow.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private PessoaJuridicaEntity UpdateEntity(PessoaJuridicaEntity entity, PessoaJuridicaUpdateModel model)
        {
            entity.Id = model.Id;
            entity.PessoaId = model.PessoaId;
            entity.RazaoSocial = model.RazaoSocial;
            entity.NomeFantasia = model.NomeFantasia;
            entity.CNPJ = model.CNPJ;
            entity.Pessoa = _mapper.Map<PessoaEntity>(model.Pessoa);
            entity.Socios = _mapper.Map<List<PessoaVinculoEntity>>(model.Socios);

            return entity;
        }

        public async Task<IEnumerable<PessoaJuridicaModel>> GetAll()
        {
            var result = await _pessoaJuridicaRepository
                .GetAll();

            return result
                .AsQueryable()
                .Include("Pessoa")
                .Include("Pessoa.PessoaFisica")
                .Include("Pessoa.Enderecos")
                .Include("Pessoa.Documentos")
                .Include("Pessoa.Documentos.Midia")
                .Select(x => _mapper.Map<PessoaJuridicaModel>(x));
        }

        public async Task<PessoaJuridicaModel> Get(int id)
        {
            // O include só é possível em cima de uma retorno do tipo IQueryable (Coleção):

            var result = await _pessoaJuridicaRepository
                .GetAll();

            return result
                .Include("Pessoa")
                .Include("Pessoa.PessoaFisica")
                .Include("Pessoa.Enderecos")
                .Include("Pessoa.Documentos")
                .Include("Pessoa.Documentos.Midia")
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<PessoaJuridicaModel>(x))
                .FirstOrDefault();
        }
    }
}
