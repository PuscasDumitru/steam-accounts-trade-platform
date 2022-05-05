import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AnnouncementComponent } from './announcement/announcement.component';
import { ViewAnnouncementComponent } from './announcement/view-announcement/view-announcement.component';
import { GamesComponent } from './games/games.component';

const routes: Routes = [
  { path: '', component: AnnouncementComponent },
  { path: 'view-announcement', component: ViewAnnouncementComponent },
  { path: 'games', component: GamesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
