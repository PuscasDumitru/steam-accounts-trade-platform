import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router, Route } from '@angular/router';
import { switchMap } from 'rxjs';
import { AnnouncementService } from 'src/app/shared/announcement.service';
import { Announcement } from 'src/app/shared/announcement.model';
import { GamesAccountService } from 'src/app/shared/games-account.service';

@Component({
  selector: 'app-view-announcement',
  templateUrl: './view-announcement.component.html',
  styleUrls: ['./view-announcement.component.css']
})
export class ViewAnnouncementComponent implements OnInit {

  announcement: Announcement = {} as Announcement;

  constructor(private route: ActivatedRoute, public service: AnnouncementService, public gameService: GamesAccountService) { }

  ngOnInit(): void {

    let announcement$ = this.route.queryParamMap.pipe(
      switchMap((params: ParamMap) =>
        this.service.getAnnouncement(Number(params.get('id'))))
    );

    announcement$.subscribe(
      (announcement: Announcement) => this.handleResponse(announcement)
    );

  }

  private handleResponse(announcement: Announcement) {
    this.announcement = announcement;
    console.log(this.announcement.account.steamLink);
    this.gameService.getUserGames(this.announcement.account.steamLink);

    console.log(this.announcement);
  }

}
