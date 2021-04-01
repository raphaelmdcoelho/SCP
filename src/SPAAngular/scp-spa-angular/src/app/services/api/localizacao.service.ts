import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConsultaCepModel } from 'src/app/models/localizacao/consultaCep';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LocalizacaoService {

  public controllerName: string = 'Localizacao';

  constructor(private http: HttpClient) { }

  public consultaCep(cep: string): Observable<ConsultaCepModel> {
    return this.http.get<ConsultaCepModel>(`${environment.urlApiBase}/${this.controllerName}/${cep}`,);
  }
}
