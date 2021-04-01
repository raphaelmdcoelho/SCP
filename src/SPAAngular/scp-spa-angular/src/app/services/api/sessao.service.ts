import { Injectable } from '@angular/core';
import { UsuarioModel } from 'src/app/models/usuario/usuario';

@Injectable({
  providedIn: 'root'
})
export class SessaoService {

  public isLogado(): boolean {
    let isLogado = localStorage.getItem('isLogado');

    if(isLogado != null){
      return true;
    }

    return false;
  }

  public setLogado(value: boolean) {
    localStorage.setItem('isLogado', JSON.stringify(value));
  }

  public setUsuario(value: UsuarioModel) {
    localStorage.setItem('usuario', JSON.stringify(value));
  }

  public getUsuario(): UsuarioModel {
    let result: UsuarioModel = new UsuarioModel();
    let usuario: any = localStorage.getItem('usuario') != null ? localStorage.getItem('usuario') : '';

    if (usuario != null && usuario != undefined) {
      result = JSON.parse(usuario.toString());
    }
    return result;
  }

  public setToken(value: string) {
    localStorage.setItem('token', value);
  }

  public getToken(): string {
    let result: any = null;
    let token = localStorage.getItem('token');

    if(token != null){
      result = token.toString();
    }

    return result;
  }

  public limparSessao() {
    localStorage.clear();
  }

  constructor() { }
}
