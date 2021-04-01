import { PessoaModel } from '../pessoa/pessoa';

export class PessoaFisicaModel {
        
    public id: number;
    public pessoaId: number;

    public primeiroNome: string;
    public sobrenome: string;
    public dthNascimento: Date;
    public genero: string;
    public cpf: string;
    public rg: string;
    public altura: string;
    public peso: string;

    public pessoa: PessoaModel;

    // public List<ProfissaoVinculoEntity> Profissoes { get; set; }
    // public List<PessoaVinculoEntity> EmpresasVinculadas { get; set; }
    
constructor() { }

}
