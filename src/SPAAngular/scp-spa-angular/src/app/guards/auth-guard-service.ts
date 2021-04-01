// src/app/auth/auth-guard.service.ts
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { SessaoService } from '../services/api/sessao.service';
@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(public sessaoService: SessaoService, public router: Router) {}
  canActivate(): boolean {

    if (!this.sessaoService.isLogado()) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}