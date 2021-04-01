import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedListPessoaFisica } from 'src/app/models/pagedList/PagedListPessoaFisica';
import { PessoaFisicaModel } from 'src/app/models/pessoa-fisica/pessoa-fisica';
import { ResponsePessoaFisicaAddModel } from 'src/app/models/pessoa-fisica/response-pessoa-fisica-add';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PessoaFisicaService {

  public controllerName: string = 'PessoaFisica';

  constructor(private http: HttpClient) { }

  public add(pessoaFisicaModel: PessoaFisicaModel): Observable<ResponsePessoaFisicaAddModel> {
    return this.http.post<ResponsePessoaFisicaAddModel>(`${environment.urlApiBase}/${this.controllerName}/`, pessoaFisicaModel);
  }

  public list(): Observable<Array<PessoaFisicaModel>> {
    return this.http.get<Array<PessoaFisicaModel>>(`${environment.urlApiBase}/${this.controllerName}/`);
  }

  public listPagedList(pagedListPessoaFisica: PagedListPessoaFisica): Observable<Array<PessoaFisicaModel>> {
    return this.http.post<Array<PessoaFisicaModel>>(`${environment.urlApiBase}/${this.controllerName}/GetAllPagedList`, pagedListPessoaFisica);
  }
}
