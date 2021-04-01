import { Guid } from 'guid-typescript';
import { PessoaModel } from '../pessoa/pessoa';

export class EnderecoModel {

    public cod: Guid;

    public pessoaId: Number;
    public isCorrespondencia: boolean;
    public logradouro: string;
    public numeroPorta: string;
    public cep: string;
    public uf: string;
    public cidade: string;
    public bairro: string;

    public pessoa: PessoaModel;

}