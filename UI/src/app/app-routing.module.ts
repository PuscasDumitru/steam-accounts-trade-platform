import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AnnouncementComponent } from './announcement/announcement.component';

const routes: Routes = [

  {path: 'weatherforecast', component: AnnouncementComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
