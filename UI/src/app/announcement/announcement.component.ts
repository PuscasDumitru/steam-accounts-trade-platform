import { Component, OnInit } from '@angular/core';
import { Announcement } from '../shared/announcement.model';
import { AnnouncementService } from '../shared/announcement.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  styleUrls: ['./announcement.component.css']
})
export class AnnouncementComponent implements OnInit {

  constructor(public service: AnnouncementService, private router: Router) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  onGetAnnouncement(announcement: Announcement) {
    let route = '/view-announcement';
    this.router.navigate([route], { queryParams: { id: announcement.id } });
  }

}
