import { Component } from '@angular/core';
import { SessaoService } from './services/api/sessao.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  title = 'SCP';

  constructor(public sessaoService: SessaoService) {
  }

  OnInit() {
    
  }
}
