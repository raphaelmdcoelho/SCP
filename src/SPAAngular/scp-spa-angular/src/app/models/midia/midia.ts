import { Guid } from 'guid-typescript';

export class MidiaModel {

    public cod: Guid;

    public nome: string;
    public conteudo: string | ArrayBuffer | null;
    public extensao: string | undefined;

}