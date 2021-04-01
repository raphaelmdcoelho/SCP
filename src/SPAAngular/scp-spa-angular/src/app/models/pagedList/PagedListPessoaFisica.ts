import { Guid } from 'guid-typescript';
import { PessoaFisicaFilter } from '../pessoa-fisica/pessoa-fisica-filter';
import { PagedList } from './pagedList';

export class PagedListPessoaFisica extends PagedList {

    pessoaFisicaFilter: PessoaFisicaFilter;

}