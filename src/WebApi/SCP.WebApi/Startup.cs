using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SCP.CrossCutting.Configuration;
using SCP.CrossCutting.MapConfiguration.Cargo;
using SCP.CrossCutting.MapConfiguration.Contato;
using SCP.CrossCutting.MapConfiguration.Documento;
using SCP.CrossCutting.MapConfiguration.Endereco;
using SCP.CrossCutting.MapConfiguration.Historico;
using SCP.CrossCutting.MapConfiguration.Midia;
using SCP.CrossCutting.MapConfiguration.Pessoa;
using SCP.CrossCutting.MapConfiguration.PessoaFisica;
using SCP.CrossCutting.MapConfiguration.PessoaJuridica;
using SCP.CrossCutting.MapConfiguration.PessoaVinculo;
using SCP.CrossCutting.MapConfiguration.Profissao;
using SCP.CrossCutting.MapConfiguration.ProfissaoVinculo;
using SCP.CrossCutting.MapConfiguration.Usuario;
using SCP.Infrastructure.Communication.Localizacao;
using SCP.Repository.Context;
using SCP.Repository.Repositories.BaseRepository;
using SCP.Repository.Repositories.Cargo;
using SCP.Repository.Repositories.Documento;
using SCP.Repository.Repositories.Endereco;
using SCP.Repository.Repositories.Historico;
using SCP.Repository.Repositories.PessoaFisica;
using SCP.Repository.Repositories.PessoaJuridica;
using SCP.Repository.Repositories.PessoaVinculo;
using SCP.Repository.Repositories.Profissao;
using SCP.Repository.Repositories.Usuario;
using SCP.Repository.UoW;
using SCP.Services.Authentication;
using SCP.Services.Cargo;
using SCP.Services.Documento;
using SCP.Services.Historico;
using SCP.Services.Localizacao.Cep;
using SCP.Services.Localizacao.Endereco;
using SCP.Services.Pessoa;
using SCP.Services.PessoaFisica;
using SCP.Services.PessoaJuridica;
using SCP.Services.PessoaVinculo;
using SCP.Services.Profissao;
using SCP.Services.Token;
using SCP.Services.Usuario;
using System.Text;

namespace SCP.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //Load Data:
            SetAppConfiguration();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add Cors:
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                //TODO: ajustar
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Configuração para evitar Referência Circular:
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Adição de autenticação:
            var key = Encoding.ASCII.GetBytes(AuthenticationConfiguration.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Swagger:
            services.AddSwaggerGen();

            // ID do contexto do banco de dados:
            services.AddDbContext<BaseContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            // IoC - Repository:
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IPessoaFisicaRepository), typeof(PessoaFisicaRepository));
            services.AddTransient(typeof(IPessoaJuridicaRepository), typeof(PessoaJuridicaRepository));
            services.AddTransient(typeof(IEnderecoRepository), typeof(EnderecoRepository));
            services.AddTransient(typeof(IDocumentoRepository), typeof(DocumentoRepository));
            services.AddTransient(typeof(IProfissaoRepository), typeof(ProfissaoRepository));
            services.AddTransient(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddTransient(typeof(ICargoRepository), typeof(CargoRepository));
            services.AddTransient(typeof(IPessoaVinculoRepository), typeof(PessoaVinculoRepository));
            services.AddTransient(typeof(IHistoricoRepository), typeof(HistoricoRepository));

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // IoC - Services:
            services.AddTransient<IPessoaFisicaService, PessoaFisicaService>();
            services.AddTransient<IPessoaJuridicaService, PessoaJuridicaService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<IDocumentoService, DocumentoService>();
            services.AddTransient<IProfissaoService, ProfissaoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ICargoService, CargoService>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaVinculoService, PessoaVinculoService>();
            services.AddTransient<IHistoricoService, HistoricoService>();

            services.AddTransient<ICepService, CepService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ILocalizacaoClient, LocalizacaoClient>();

            // Mapeamento de Model -> Entity e Entity -> Model:
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProfissaoProfile>();
                cfg.AddProfile<CargoProfile>();
                cfg.AddProfile<PessoaProfile>();
                cfg.AddProfile<PessoaFisicaProfile>();
                cfg.AddProfile<EnderecoProfile>();
                cfg.AddProfile<DocumentoProfile>();
                cfg.AddProfile<MidiaProfile>();
                cfg.AddProfile<UsuarioProfile>();
                cfg.AddProfile<HistoricoProfile>();
                cfg.AddProfile<ProfissaoVinculoProfile>();
                cfg.AddProfile<PessoaJuridicaProfile>();
                cfg.AddProfile<PessoaVinculoProfile>();
                cfg.AddProfile<ContatoProfile>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SetAppConfiguration()
        {
            AuthenticationConfiguration.Secret = Configuration["Authentication:Secret"];
        }
    }
}
