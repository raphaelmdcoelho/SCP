import { Guid } from 'guid-typescript';
import { PessoaModel } from '../pessoa/pessoa';

export class ContatoModel {

    public pessoaId: Number;

    public dDD: string;
    public numero: string;
    public tipo: string;

    public cod: Guid;

    public pessoa: PessoaModel;

}