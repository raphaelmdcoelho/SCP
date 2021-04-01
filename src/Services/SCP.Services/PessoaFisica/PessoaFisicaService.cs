using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCP.CrossCutting.MapModels.PagedList.PagedListPessoaFisica;
using SCP.CrossCutting.MapModels.PessoaFisica;
using SCP.Domain.Pessoa;
using SCP.Domain.PessoaFisica;
using SCP.Domain.PessoaVinculo;
using SCP.Domain.ProfissaoVinculo;
using SCP.Repository.Repositories.PessoaFisica;
using SCP.Repository.UoW;
using SCP.Services.Documento;
using SCP.Services.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Services.PessoaFisica
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaService _pessoaService;
        private readonly IDocumentoService _documentoService;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PessoaFisicaService(IPessoaService pessoaService,
            IDocumentoService documentoService,
            IPessoaFisicaRepository pessoaFisicaRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _pessoaService = pessoaService;
            _documentoService = documentoService;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ResponsePessoaFisicaAddModel> Add(PessoaFisicaAddModel model)
        {
            // TODO: Validation: (CPF e Id não podem ser repetidos)

            try
            {
                _pessoaService.ConfigurePessoaToAdd(model.Pessoa);

                foreach (var documento in model.Pessoa.Documentos)
                {
                    _documentoService.ConfigureDocumentoToAdd(documento);
                }

                var pessoaFisicaEntity = _mapper.Map<PessoaFisicaEntity>(model);

                var pessoaFisicaEntityDb = await _pessoaFisicaRepository.Insert(pessoaFisicaEntity);

                _uow.SaveChanges();

                return new ResponsePessoaFisicaAddModel { PessoaFisica = _mapper.Map<PessoaFisicaModel>((PessoaFisicaEntity)pessoaFisicaEntityDb.Entity), Message = "Pessoa Física Registrada com Sucesso", Success = true };
            }
            catch(Exception ex)
            {
                return new ResponsePessoaFisicaAddModel { PessoaFisica = null, Message = ex.Message, Success = false };
            }
        }

        public async Task<ResponsePessoaFisicaRemoveModel> Remove(int id)
        {
            try
            {
                var entityResult = await _pessoaFisicaRepository.GetAll();
                var entity = entityResult.Where(pf => pf.Id == id).FirstOrDefault();

                if (entity != null)
                {
                    _pessoaFisicaRepository.Delete(entity.Id);
                    _uow.SaveChanges();

                    return new ResponsePessoaFisicaRemoveModel { Success = true, Message = "Pessoa removida com sucesso" };
                }

                return new ResponsePessoaFisicaRemoveModel { Success = false, Message = "Pessoa não existe" };
            }
            catch (Exception)
            {
                return new ResponsePessoaFisicaRemoveModel { Success = true, Message = "Ocorreu um erro ao remover a pessoa" };
            }
        }

        public async Task<bool> Update(PessoaFisicaUpdateModel model)
        {
            try
            {
                var entityDb = await _pessoaFisicaRepository.GetById(model.Id);
                var entity = UpdateEntity(entityDb, model);

                _pessoaFisicaRepository.Update(entity);
                _uow.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private PessoaFisicaEntity UpdateEntity(PessoaFisicaEntity entity, PessoaFisicaUpdateModel model)
        {
            entity.Id = model.Id;
            entity.PessoaId = model.PessoaId;
            entity.PrimeiroNome = model.PrimeiroNome;
            entity.Sobrenome = model.Sobrenome;
            entity.DthNascimento = model.DthNascimento;
            entity.Genero = model.Genero;
            entity.CPF = model.CPF;
            entity.RG = model.RG;
            entity.Altura = model.Altura;
            entity.Peso = model.Peso;
            entity.Pessoa = _mapper.Map<PessoaEntity>(model.Pessoa);
            entity.Profissoes = _mapper.Map<List<ProfissaoVinculoEntity>>(model.Profissoes);
            entity.EmpresasVinculadas = _mapper.Map<List<PessoaVinculoEntity>>(model.EmpresasVinculadas);

            return entity;
        }

        public async Task<IEnumerable<PessoaFisicaModel>> GetAll()
        {
            var query = await _pessoaFisicaRepository
                .GetAll();

            return query.AsQueryable()
                .Include("Pessoa")
                .Include("Pessoa.Contatos")
                .Include("Pessoa.Enderecos")
                .Include("Pessoa.Documentos")
                .Include("Pessoa.Documentos.Midia")
                .Select(x => _mapper.Map<PessoaFisicaModel>(x));
        }

        public async Task<List<PessoaFisicaModel>> GetAllPagedList(PagedListPessoaFisica pagedListPessoaFisica)
        {
            var queryFilter = await _pessoaFisicaRepository
                .GetAll();

            if (!string.IsNullOrEmpty(pagedListPessoaFisica.PessoaFisicaFilter.PrimeiroNome))
            {
                queryFilter = queryFilter.Where(x => x.PrimeiroNome.Contains(pagedListPessoaFisica.PessoaFisicaFilter.PrimeiroNome));
            }

            if (!string.IsNullOrEmpty(pagedListPessoaFisica.PessoaFisicaFilter.Sobrenome))
            {
                queryFilter = queryFilter.Where(x => x.Sobrenome.Contains(pagedListPessoaFisica.PessoaFisicaFilter.Sobrenome));
            }

            if (!string.IsNullOrEmpty(pagedListPessoaFisica.PessoaFisicaFilter.Cpf))
            {
                queryFilter = queryFilter.Where(x => x.CPF.Contains(pagedListPessoaFisica.PessoaFisicaFilter.Cpf));
            }

            if (!string.IsNullOrEmpty(pagedListPessoaFisica.PessoaFisicaFilter.Rg))
            {
                queryFilter = queryFilter.Where(x => x.RG.Contains(pagedListPessoaFisica.PessoaFisicaFilter.Rg));
            }

            if (pagedListPessoaFisica.PessoaFisicaFilter.Genero != null)
            {
                queryFilter = queryFilter.Where(x => x.Genero == pagedListPessoaFisica.PessoaFisicaFilter.Genero);
            }

            if (pagedListPessoaFisica.PessoaFisicaFilter.DthNascimento != null)
            {
                queryFilter.Where(x => x.DthNascimento == pagedListPessoaFisica.PessoaFisicaFilter.DthNascimento);
            }

            queryFilter = queryFilter = queryFilter.Where(x => x.Pessoa.IsAtivo == true);

            var query = queryFilter
                .Include("Pessoa")
                .Include("Pessoa.Contatos")
                .Include("Pessoa.Enderecos")
                .Include("Pessoa.Documentos")
                .Include("Pessoa.Documentos.Midia")
                .Select(x => _mapper.Map<PessoaFisicaModel>(x)).ToList();

            //var result = new PagedListPessoaFisicaResult();
            //result.Count = query.Count();

            //var finalList = query.Skip(pagedListPessoaFisica.PageNumber - 1 * pagedListPessoaFisica.PageSize).Take(pagedListPessoaFisica.PageSize);

            //result.PessoaFisicaResult = finalList.ToList();

            return query;
        }

        public async Task<PessoaFisicaModel> Get(int id)
        {
            // O include só é possível em cima de uma retorno do tipo IQueryable (Coleção):

            var query = await _pessoaFisicaRepository
                .GetAll();

            return query.Include("Pessoa")
                .Include("Pessoa.Enderecos")
                .Include("Pessoa.Documentos")
                .Include("Pessoa.Documentos.Midia")
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<PessoaFisicaModel>(x))
                .FirstOrDefault();
        }
    }
}
