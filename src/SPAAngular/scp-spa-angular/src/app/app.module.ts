import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NavbarComponent } from './common/navbar/navbar.component';
import { LoginComponent } from './pages/login/login.component';
import { SessaoService } from './services/api/sessao.service';
import { AuthenticationService } from './services/api/authentication.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TokenInterceptor } from './interceptors/token-interceptor';
import { AuthGuardService } from './guards/auth-guard-service';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PesquisarPessoaFisicaComponent } from './pages/pessoa-fisica/pesquisar-pessoa-fisica/pesquisar-pessoa-fisica.component';
import { NgWizardConfig } from 'ng-wizard/lib/utils/interfaces';
import { NgWizardModule, THEME } from 'ng-wizard';
import { AdicionarPessoaFisicaComponent } from './pages/pessoa-fisica/adicionar-pessoa-fisica/adicionar-pessoa-fisica.component';
import { NgxMaskModule } from 'ngx-mask';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const ngWizardConfig: NgWizardConfig = {
  theme: THEME.default,
  lang: { next: 'Próximo', previous: 'Voltar' }
};

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    NavbarComponent,
    PesquisarPessoaFisicaComponent,
    AdicionarPessoaFisicaComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot({
      countDuplicates: true,
      timeOut: 3000,
      progressAnimation: 'decreasing',
      progressBar: true
    }),
    NgWizardModule.forRoot(ngWizardConfig),
    NgxMaskModule.forRoot(),
    NgbModule,
  ],
  providers: [
    SessaoService,
    AuthGuardService,
    AuthenticationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
