using System.ComponentModel;

namespace SCP.Domain.Enumeracoes
{
    public enum PessoaTipoEnum
    {
        [Description("Pessoa Física")]
        PessoaFisica = 1,
        [Description("Pessoa Jurídica")]
        PessoaJuridica = 2
    }
}
