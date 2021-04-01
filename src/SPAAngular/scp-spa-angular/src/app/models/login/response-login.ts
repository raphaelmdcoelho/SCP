import { UsuarioModel } from '../usuario/usuario';

export class ResponseLoginModel {
    public token: string;
    public message: string;
    public user: UsuarioModel;

    constructor() {

    }
}