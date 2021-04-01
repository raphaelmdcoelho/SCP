import { PessoaModel } from '../pessoa/pessoa';
import { PessoaFisicaModel } from './pessoa-fisica';

export class ResponsePessoaFisicaAddModel {
    
public success: boolean;
public message: string;
public pessoaFisica: PessoaFisicaModel
    
constructor() { }

}
