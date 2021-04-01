import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';
import { LoginModel } from 'src/app/models/login/login';
import { ResponseLoginModel } from 'src/app/models/login/response-login';
import { AuthenticationService } from 'src/app/services/api/authentication.service';
import { SessaoService } from 'src/app/services/api/sessao.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public formGroup: FormGroup;

  constructor(private sessaoService: SessaoService,
    private authenticationService: AuthenticationService,
    private formBuilder: FormBuilder,
    private router: Router,
    private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.criarFormulario();
  }

  public criarFormulario() {
    this.formGroup = this.formBuilder.group({
      email: [null, Validators.required],
      senha: [null, Validators.required]
    });
  }

  public logar() {
    if(!this.formGroup.valid) {
      this.toastr.error('Preencha os campos!');
      return;
    }

    let loginModel = new LoginModel();
    loginModel.username = this.formGroup.get('email')?.value;
    loginModel.senha = this.formGroup.get('senha')?.value;

    this.authenticationService.logar(loginModel)
      .subscribe((loginResult: ResponseLoginModel) => {
        if(loginResult.token != null){

          this.sessaoService.setToken(loginResult.token);
          this.sessaoService.setLogado(true);
          this.sessaoService.setUsuario(loginResult.user);

          this.router.navigate(['/home']);
          return;
        } else {
          this.toastr.error('Nome de usuário ou senha errados!');
          return;
        }
      }, (error) => {
        this.toastr.error('Nome de usuário ou senha errados!');
        return;
      });
  }

}
