import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessaoService } from 'src/app/services/api/sessao.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private sessaoService: SessaoService,
    private router: Router) { }

  ngOnInit(): void {
  }

  public logout() {
    this.sessaoService.limparSessao();
    this.router.navigate(['/login']);
  }

}
