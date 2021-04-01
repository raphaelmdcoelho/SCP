import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { STEP_STATE, NgWizardConfig, THEME, NgWizardService, StepChangedArgs, StepValidationArgs } from 'ng-wizard';
import { Toast, ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { ContatoModel } from 'src/app/models/contato/contato';
import { PessoaFisicaModel } from 'src/app/models/pessoa-fisica/pessoa-fisica';
import { PessoaModel } from 'src/app/models/pessoa/pessoa';
import { SessaoService } from 'src/app/services/api/sessao.service';
import { Guid } from 'guid-typescript';
import { LocalizacaoService } from 'src/app/services/api/localizacao.service';
import { EnderecoModel } from 'src/app/models/localizacao/endereco';
import { DocumentoModel } from 'src/app/models/documento/documento';
import { MidiaModel } from 'src/app/models/midia/midia';
import { PessoaFisicaService } from 'src/app/services/api/pessoa-fisica.service';
import { ThrowStmt } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adicionar-pessoa-fisica',
  templateUrl: './adicionar-pessoa-fisica.component.html',
  styleUrls: ['./adicionar-pessoa-fisica.component.scss']
})
export class AdicionarPessoaFisicaComponent implements OnInit {

  public pageContato: number = 1;
  public pageSizeContato: number = 2;

  public CPF_MASK: string = "000.000.000-00";
  public RG_MASK: string = "0.000.000";

  public CONTATO_MASK: string = "00000-0000";
  public DDD_MASK: string = "00";

  formGroupDadosPessoais: FormGroup;
  formGroupContato: FormGroup;
  formGroupEndereco: FormGroup;
  formGroupDocumento: FormGroup;
  formGroupProfissao: FormGroup;

  pessoaFisicaModel: PessoaFisicaModel;

  listContatos: Array<ContatoModel>;
  listEnderecos: Array<EnderecoModel>;
  listDocumentos: Array<DocumentoModel>;

  public termoAceite: boolean = false;
  public possuiVinculoPJ: boolean = false;

  extensaoDoc: string | undefined;
  //conteudoDoc: string | ArrayBuffer | null;
  conteudoDoc: string[];
  fileToUpload: File | null;

  stepStates = {
    normal: STEP_STATE.normal,
    disabled: STEP_STATE.disabled,
    error: STEP_STATE.error,
    hidden: STEP_STATE.hidden,
  };

  config: NgWizardConfig = {
    selected: 0,
    theme: THEME.dots,
    toolbarSettings: {
      toolbarExtraButtons: [
        { text: 'Salvar', class: 'btn btn-info', event: () => { this.salvar(); } }
      ],
    }
  };

  constructor(private ngWizardService: NgWizardService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private sessaoService: SessaoService,
    private localizacaoService: LocalizacaoService,
    private pessoaFisicaService: PessoaFisicaService,
    private router: Router) {
  }

  ngOnInit() {
    this.criarFormularioDadosPessoais();
    this.criarFormularioContato();
    this.criarFormularioEndereco();
    this.criarFormularioDocumento();
    this.criarFormularioProfissao();
  }

  showPreviousStep(event?: Event) {
    this.ngWizardService.previous();
  }

  showNextStep(event?: Event) {
    this.ngWizardService.next();
  }

  resetWizard(event?: Event) {
    this.ngWizardService.reset();
  }

  setTheme(theme: THEME) {
    this.ngWizardService.theme(theme);
  }

  stepChanged(args: StepChangedArgs) {
    console.log(args.step);
  }

  isValidTypeBoolean: boolean = true;

  isValidFunctionReturnsBoolean(args: StepValidationArgs) {
    return true;
  }

  isValidFunctionReturnsObservable(args: StepValidationArgs) {
    return of(true);
  }

  criarFormularioDadosPessoais() {
    this.formGroupDadosPessoais = this.formBuilder.group({
      primeiroNome: [null],
      sobrenome: [null],
      genero: [null],
      cpf: [null],
      rg: [null],
      dthNascimento: [null],
      altura: [null],
      peso: [null],
    });
  }

  criarFormularioContato() {
    this.formGroupContato = this.formBuilder.group({
      tipo: [null, Validators.required],
      dDD: [null, Validators.required],
      numero: [null, Validators.required]
    });
  }

  criarFormularioEndereco() {
    this.formGroupEndereco = this.formBuilder.group({
      tipo: [null, Validators.required],
      cep: [null, Validators.required],
      cidade: [null],
      uf: [null],
      logradouro: [null],
      numeroPorta: [null, Validators.required],
    });
  }

  criarFormularioDocumento() {
    this.formGroupDocumento = this.formBuilder.group({
      tipo: [null],
      nome: [null],
    });
  }

  criarFormularioProfissao() {
    this.formGroupProfissao = this.formBuilder.group({
      idcTipoProfissao: [null],
      idcCargo: [null],
      txtSalario: [null],
      dthInicio: [null],
    });
  }

  formToModel(): Observable<PessoaFisicaModel> {
    return new Observable<PessoaFisicaModel>((observer) => {

      if (this.pessoaFisicaModel == null) {
        this.pessoaFisicaModel = new PessoaFisicaModel();
        this.pessoaFisicaModel.pessoa = new PessoaModel();
        this.pessoaFisicaModel.pessoa.contatos = new Array<ContatoModel>();
      }

      // Pessoa Física:
      this.pessoaFisicaModel.primeiroNome = this.formGroupDadosPessoais.get('primeiroNome')?.value;
      this.pessoaFisicaModel.sobrenome = this.formGroupDadosPessoais.get('sobrenome')?.value;
      this.pessoaFisicaModel.dthNascimento = this.formGroupDadosPessoais.get('dthNascimento')?.value;
      this.pessoaFisicaModel.genero = this.formGroupDadosPessoais.get('genero')?.value;
      this.pessoaFisicaModel.cpf = this.formGroupDadosPessoais.get('cpf')?.value;
      this.pessoaFisicaModel.rg = this.formGroupDadosPessoais.get('rg')?.value;
      this.pessoaFisicaModel.altura = this.formGroupDadosPessoais.get('altura')?.value;
      this.pessoaFisicaModel.peso = this.formGroupDadosPessoais.get('peso')?.value;

      // Pessoa:
      // Os outros dados de Pessoa são configurados pelo serviço de back end (addPessoaFisica).
      this.pessoaFisicaModel.pessoa.usuarioId = this.sessaoService.getUsuario().id;

      // Contato:
      this.pessoaFisicaModel.pessoa.contatos = this.listContatos;
      
      // Endereço:
      this.pessoaFisicaModel.pessoa.enderecos = this.listEnderecos;

      // Documento:
      this.pessoaFisicaModel.pessoa.documentos = this.listDocumentos;

      // Profissão:
      

      observer.next(this.pessoaFisicaModel);

    });
  }

  isFormsValid(): boolean {
    let result: boolean = true;

    if (!this.formGroupDadosPessoais.valid) {
      this.toastr.error('Dados pessoais incompletos!');
      result = false;
    }

    if (!(this.listContatos != null && this.listContatos.length > 0)) {
      this.toastr.error('Dados de contatos incompletos!');
      result = false;
    }

    if (!(this.listEnderecos != null && this.listEnderecos.length > 0)) {
      this.toastr.error('Dados de endereço incompletos!');
      result = false;
    }

    if (!(this.listDocumentos != null && this.listDocumentos.length > 0)) {
      this.toastr.error('Dados de documento incompletos!');
      result = false;
    }

    if (!this.formGroupProfissao) {
      this.toastr.error('Dados de transmissão incompletos!');
      result = false;
    }

    if (!this.termoAceite) {
      this.toastr.error('É necessário aceitar o termo de adesão!');
      result = false;
    }

    return result;
  }

  salvar() {

    if (this.isFormsValid()) {
      this.formToModel()
        .subscribe(pessoaFisica => {
          
          this.pessoaFisicaService.add(pessoaFisica)
            .subscribe(result => {
              this.toastr.success('Pessoa Física cadastrada com sucesso!');
              this.router.navigate(['/home']);
            }, (error) => {
              this.toastr.error('Ocorreu um erro ao salvar a pessoa físia.');
            });

          this.toastr.success('Cadastro realizado com sucesso!');
        }, (error) => {
          this.toastr.error('Ocorreu um erro ao salvar o registro!');
        });
    }
  }

  public changeVinculoPJ() {
    if(this.possuiVinculoPJ) {
      this.possuiVinculoPJ = false;
    } else {
      //TODO: limpar form de vinculo:
      this.possuiVinculoPJ = true;
    } 
  }

  public adicionarContato() {

    if(this.listContatos == null){
      this.listContatos = new Array<ContatoModel>();
    }

    if(!this.formGroupContato.valid) {
      this.toastr.warning('Preencha todos os campos!');
      return;
    }

    let contato = new ContatoModel();

    contato.cod = Guid.create();
    contato.dDD = this.formGroupContato.get('dDD')?.value;
    contato.tipo = this.formGroupContato.get('tipo')?.value;
    contato.numero = this.formGroupContato.get('numero')?.value;

    this.listContatos.push(contato);
    this.cleanFormContato();
  }

  cleanFormContato() {
    this.formGroupContato.reset();
  }

  cleanFormEndereco() {
    this.formGroupEndereco.reset();
  }

  cleanFormDocumento() {
    this.formGroupDocumento.reset();
  }

  consultaCep() {
    this.localizacaoService.consultaCep(this.formGroupEndereco.get('cep')?.value)
      .subscribe(consultaCepModel => {
        if(consultaCepModel.cep == null) {
          this.toastr.error('Endereço não localizado!');
          return;
        }
        this.formGroupEndereco.patchValue({
          cidade: consultaCepModel.localidade,
          uf: consultaCepModel.uf,
          logradouro: consultaCepModel.logradouro,
          numero: [null],
        });
      });
  }

  public adicionarEndereco() { 

    if(this.listEnderecos == null){
      this.listEnderecos = new Array<EnderecoModel>();
    }

    if(!this.formGroupEndereco.valid) {
      this.toastr.warning('Preencha todos os campos!');
      return;
    }

    let endereco = new EnderecoModel();

    endereco.cod = Guid.create();
    endereco.logradouro = this.formGroupEndereco.get('logradouro')?.value;
    endereco.numeroPorta = this.formGroupEndereco.get('numeroPorta')?.value;
    endereco.cep = this.formGroupEndereco.get('cep')?.value;
    endereco.uf = this.formGroupEndereco.get('uf')?.value;
    endereco.cidade = this.formGroupEndereco.get('cidade')?.value;
    endereco.bairro = this.formGroupEndereco.get('bairro')?.value;

    this.listEnderecos.push(endereco);
    this.cleanFormContato();
  }

  handleFileInput(event: EventTarget | null) {
    let htmlInput = (event as HTMLInputElement);
    let files: FileList;
    files = (htmlInput?.files as FileList);
    this.fileToUpload = files[0];

    this.formGroupDocumento.patchValue({
      nome: this.fileToUpload?.name
    });

    this.extensaoDoc = this.fileToUpload?.type.substr(this.fileToUpload?.type.indexOf('/') + 1, this.fileToUpload?.type.length -1);

    const reader = new FileReader();
    reader.readAsDataURL(this.fileToUpload);
    reader.onload = () => {
        this.conteudoDoc = (reader.result as string).split(';');
    };
}

  public adicionarDocumento() {

    if(this.listDocumentos == null){
      this.listDocumentos = new Array<DocumentoModel>();
    }

    if(!this.formGroupDocumento.valid) {
      this.toastr.warning('Preencha todos os campos!');
      return;
    }

    let documento = new DocumentoModel();

    documento.cod = Guid.create();
    documento.tipo = this.formGroupDocumento.get('tipo')?.value;
    documento.midia = new MidiaModel();
    documento.midia.cod = Guid.create();
    documento.midia.nome = this.formGroupDocumento.get('nome')?.value;
    documento.midia.conteudo = this.conteudoDoc[1];
    documento.midia.extensao = this.extensaoDoc;

    this.listDocumentos.push(documento);
    this.cleanFormContato();
  }

}
