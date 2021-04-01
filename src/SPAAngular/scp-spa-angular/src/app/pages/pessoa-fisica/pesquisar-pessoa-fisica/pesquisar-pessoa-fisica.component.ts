import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PagedListPessoaFisica } from 'src/app/models/pagedList/PagedListPessoaFisica';
import { PessoaFisicaModel } from 'src/app/models/pessoa-fisica/pessoa-fisica';
import { PessoaFisicaFilter } from 'src/app/models/pessoa-fisica/pessoa-fisica-filter';
import { PessoaFisicaService } from 'src/app/services/api/pessoa-fisica.service';

@Component({
  selector: 'app-pesquisar-pessoa-fisica',
  templateUrl: './pesquisar-pessoa-fisica.component.html',
  styleUrls: ['./pesquisar-pessoa-fisica.component.scss']
})
export class PesquisarPessoaFisicaComponent implements OnInit {

  public listPessoaFisica: Array<PessoaFisicaModel>;

  public CPF_MASK: string = "000.000.000-00";
  public RG_MASK: string = "0.000.000";

  public page: number = 1;
  public pageSize: number = 3;
  public pagedListPessoaFisica: PagedListPessoaFisica;

  formGroupPesquisar: FormGroup;

  constructor(private pessoaFisicaService: PessoaFisicaService,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    
    this.pagedListPessoaFisica = new PagedListPessoaFisica();
    this.pagedListPessoaFisica.pessoaFisicaFilter = new PessoaFisicaFilter();
    this.pagedListPessoaFisica.pageNumber = this.page;
    this.pagedListPessoaFisica.pageSize = this.pageSize;

    this.pessoaFisicaService.listPagedList(this.pagedListPessoaFisica)
      .subscribe(pessoaFisicaList => {

        this.listPessoaFisica = pessoaFisicaList;
      });

      this.criarFormularioPesquisar();
  }

  public pesquisar() {

    debugger;
    this.pagedListPessoaFisica = new PagedListPessoaFisica();
    this.pagedListPessoaFisica.pessoaFisicaFilter = new PessoaFisicaFilter();
    this.pagedListPessoaFisica.pageNumber = this.page;
    this.pagedListPessoaFisica.pageSize = this.pageSize;

    this.pagedListPessoaFisica.pessoaFisicaFilter.primeiroNome = this.formGroupPesquisar.get('primeiroNome')?.value;
    this.pagedListPessoaFisica.pessoaFisicaFilter.sobrenome = this.formGroupPesquisar.get('sobrenome')?.value;
    this.pagedListPessoaFisica.pessoaFisicaFilter.cpf = this.formGroupPesquisar.get('cpf')?.value;
    this.pagedListPessoaFisica.pessoaFisicaFilter.rg = this.formGroupPesquisar.get('rg')?.value;
    this.pagedListPessoaFisica.pessoaFisicaFilter.genero = this.formGroupPesquisar.get('genero')?.value;
    this.pagedListPessoaFisica.pessoaFisicaFilter.dthNascimento = this.formGroupPesquisar.get('dthNascimento')?.value;

    this.pessoaFisicaService.listPagedList(this.pagedListPessoaFisica)
      .subscribe(pessoaFisicaList => {

        this.listPessoaFisica = pessoaFisicaList;
      });
  }

  criarFormularioPesquisar() {
    this.formGroupPesquisar = this.formBuilder.group({
      primeiroNome: [null],
      sobrenome: [null],
      genero: [null],
      cpf: [null],
      rg: [null],
      dthNascimento: [null],
    });
  }

}
