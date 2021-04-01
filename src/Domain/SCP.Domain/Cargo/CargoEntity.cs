using SCP.Domain.Base;
using SCP.Domain.ProfissaoVinculo;
using System.Collections.Generic;

namespace SCP.Domain.Cargo
{
    public class CargoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }

        public List<ProfissaoVinculoEntity> ProfissoesVinculos { get; set; }
    }
}
