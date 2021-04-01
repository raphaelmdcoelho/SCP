
using SCP.CrossCutting.MapModels.Pessoa;

namespace SCP.Services.Pessoa
{
    public interface IPessoaService
    {
        void ConfigurePessoaToAdd(PessoaModel model);
    }
}
