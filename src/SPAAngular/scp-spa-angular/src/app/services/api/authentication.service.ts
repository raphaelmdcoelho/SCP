import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from 'src/app/models/login/login';
import { ResponseLoginModel } from 'src/app/models/login/response-login';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  public controllerName: string = 'Auth';

  constructor(private http: HttpClient) { }

  // getHeroes(loginModel: LoginModel): Observable<ResponseLoginModel> {
  //   return this.http.get<ResponseLoginModel>(Environment.urlApiBase)
  // }

  public logar(loginModel: LoginModel): Observable<ResponseLoginModel> {
    return this.http.post<ResponseLoginModel>(`${environment.urlApiBase}/${this.controllerName}/logar`, loginModel);
  }
}
