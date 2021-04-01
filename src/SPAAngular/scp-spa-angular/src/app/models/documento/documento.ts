import { Guid } from 'guid-typescript';
import { MidiaModel } from '../midia/midia';
import { PessoaModel } from '../pessoa/pessoa';

export class DocumentoModel {

    public cod: Guid;

    public midiaId: Number;
    public pessoaId: Number;
    public tipo: number;
    public dthRegistro: Date;
    public dthExclusao: Date;
    public isAtivo: boolean;

    public pessoa: PessoaModel;
    public midia: MidiaModel;

}