// src/app/auth/token.interceptor.ts
import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { SessaoService } from '../services/api/sessao.service';
import { Observable } from 'rxjs';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
    constructor(public sessaoService: SessaoService) { }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        if (this.sessaoService.isLogado()) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${this.sessaoService.getToken()}`
                }
            });
        }
        return next.handle(request);
    }
}