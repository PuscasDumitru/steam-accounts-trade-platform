import { Injectable } from '@angular/core';
import { Announcement } from './announcement.model';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:44360/api/Announcement';
  list: Announcement[];

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res => {
        this.list = res as Announcement[];
        console.log(this.list);
      });
  }

  getAnnouncement(id: number) {
    return this.http.get(`${this.baseURL}/${id}`);
  }
}
