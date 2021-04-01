import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './guards/auth-guard-service';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { AdicionarPessoaFisicaComponent } from './pages/pessoa-fisica/adicionar-pessoa-fisica/adicionar-pessoa-fisica.component';
import { PesquisarPessoaFisicaComponent } from './pages/pessoa-fisica/pesquisar-pessoa-fisica/pesquisar-pessoa-fisica.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuardService] },
  { path: 'pesquisar/pessoa-fisica', component: PesquisarPessoaFisicaComponent, canActivate: [AuthGuardService] },
  { path: 'adicionar/pessoa-fisica', component: AdicionarPessoaFisicaComponent, canActivate: [AuthGuardService] },
  { path: 'login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
