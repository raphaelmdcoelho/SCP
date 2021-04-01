import { ContatoModel } from '../contato/contato';
import { DocumentoModel } from '../documento/documento';
import { EnderecoModel } from '../localizacao/endereco';
import { PessoaFisicaModel } from '../pessoa-fisica/pessoa-fisica';

export class PessoaModel {

    public usuarioId: Number;

    public tipo: Number;
    public isAtivo: boolean;
    public dthCriacao: Date;
    public dthExclusao: Date;

    public contatos: Array<ContatoModel>;
    public enderecos: Array<EnderecoModel>;
    public documentos: Array<DocumentoModel>;
    
    //public pessoaFisica: PessoaFisica;
    
    //public PessoaJuridicaEntity PessoaJuridica { get; set; }
    //public UsuarioEntity Usuario { get; set; }
    
    //public List<HistoricoEntity> Historicos { get; set; }

}