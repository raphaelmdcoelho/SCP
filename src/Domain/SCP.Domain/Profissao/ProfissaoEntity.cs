
using SCP.Domain.Base;
using SCP.Domain.ProfissaoVinculo;
using System.Collections.Generic;

namespace SCP.Domain.Profissao
{
    public class ProfissaoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }

        public List<ProfissaoVinculoEntity> ProfissoesVinculos { get; set; }
    }
}
