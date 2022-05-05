import { Component, OnInit } from '@angular/core';
import { GamesAccountService } from '../shared/games-account.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {

  constructor(public service: GamesAccountService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

}
