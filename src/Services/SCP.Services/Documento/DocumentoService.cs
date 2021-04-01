using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCP.CrossCutting.MapModels.Documento;
using SCP.Domain.Documento;
using SCP.Repository.Repositories.Documento;
using SCP.Repository.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Services.Documento
{
    public class DocumentoService : IDocumentoService
    {
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public DocumentoService(IDocumentoRepository documentoRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _documentoRepository = documentoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ResponseDocumentoAddModel> Add(DocumentoAddModel model)
        {
            // TODO: Validation: (CPF e Id não podem ser repetidos)

            try
            {
                var documentoEntity = _mapper.Map<DocumentoEntity>(model);

                var documentoEntityDb = await _documentoRepository.Insert(documentoEntity);

                _uow.SaveChanges();

                return new ResponseDocumentoAddModel { Documento = _mapper.Map<DocumentoModel>((DocumentoEntity)documentoEntityDb.Entity), Message = "Documento Registrado com Sucesso", Success = true };
            }
            catch (Exception ex)
            {
                return new ResponseDocumentoAddModel { Documento = null, Message = ex.Message, Success = false };
            }
        }

        public async Task<ResponseDocumentoRemoveModel> Remove(int id)
        {
            try
            {
                var entityResult = await _documentoRepository.GetAll();
                var entity = entityResult.Where(pf => pf.Id == id).FirstOrDefault();

                if (entity != null)
                {
                    _documentoRepository.Delete(entity.Id);
                    _uow.SaveChanges();

                    return new ResponseDocumentoRemoveModel { Success = true, Message = "Documento removido com sucesso" };
                }

                return new ResponseDocumentoRemoveModel { Success = false, Message = "Documento não existe" };
            }
            catch (Exception)
            {
                return new ResponseDocumentoRemoveModel { Success = true, Message = "Ocorreu um erro ao remover o documento" };
            }
        }

        public async Task<IEnumerable<DocumentoModel>> GetAll()
        {
            var query = await _documentoRepository
                .GetAll();

            return query.AsQueryable()
                .Include("Midia")
                .Select(x => _mapper.Map<DocumentoModel>(x));
        }

        public async Task<DocumentoModel> Get(int id)
        {
            // O include só é possível em cima de uma retorno do tipo IQueryable (Coleção):

            var query = await _documentoRepository
                .GetAll();

            return query.Include("Midia")
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<DocumentoModel>(x))
                .FirstOrDefault();
        }

        public void ConfigureDocumentoToAdd(DocumentoModel model)
        {
            model.IsAtivo = true;
            model.DthRegistro = DateTime.Now;
            model.DthExclusao = null;
        }
    }
}
