using SCP.Domain.Base;
using SCP.Domain.Pessoa;
using SCP.Domain.PessoaVinculo;
using SCP.Domain.ProfissaoVinculo;
using System;
using System.Collections.Generic;

namespace SCP.Domain.PessoaFisica
{
    public class PessoaFisicaEntity : BaseEntity
    {
        public int PessoaId { get; set; }

        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DthNascimento { get; set; }
        public char Genero { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }

        public PessoaEntity Pessoa { get; set; }

        public List<ProfissaoVinculoEntity> Profissoes { get; set; }
        public List<PessoaVinculoEntity> EmpresasVinculadas { get; set; }
    }
}
