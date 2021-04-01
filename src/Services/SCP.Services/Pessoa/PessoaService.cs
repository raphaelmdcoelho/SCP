using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCP.CrossCutting.MapModels.Pessoa;
using SCP.Domain.Pessoa;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;
using SCP.Repository.UoW;
using System;

namespace SCP.Services.Pessoa
{
    public class PessoaService : IPessoaService
    {
        protected readonly BaseContext _context;
        private readonly IBaseRepository<PessoaEntity> _baseRepository;
        private readonly IUnitOfWork _unitWork;
        private readonly IMapper _mapper;
        private DbSet<PessoaEntity> entities;

        public PessoaService(IBaseRepository<PessoaEntity> baseRepository,
            BaseContext context,
            IMapper mapper,
            IUnitOfWork unitWork)
        {
            _context = context;
            _baseRepository = baseRepository;
            _mapper = mapper;
            _unitWork = unitWork;

            entities = context.Set<PessoaEntity>();
        }
        public void ConfigurePessoaToAdd(PessoaModel model)
        {
            model.IsAtivo = true;
            model.DthCriacao = DateTime.Now;
            model.DthExclusao = null;
        }
    }
}
