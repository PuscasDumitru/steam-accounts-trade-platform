import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Game } from './game.model';

@Injectable({
  providedIn: 'root'
})
export class GamesAccountService {

  constructor(private http: HttpClient) { }
  
  readonly baseURL = 'https://localhost:44360/api/Game';

  list: Game[];
  currentUserList: Game[];

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res => {
        this.list = res as Game[];
        console.log(this.list);
      });
  }

  getUserGames(id: string) {
    this.http.get(`${this.baseURL}/User/${id}`)
      .toPromise()
      .then(res => {
        this.currentUserList = res as Game[];
        console.log(this.currentUserList);
      });
  }
  
}
