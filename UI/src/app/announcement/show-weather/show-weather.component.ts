import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-weather',
  templateUrl: './show-weather.component.html',
  styleUrls: ['./show-weather.component.css']
})
export class ShowWeatherComponent implements OnInit {

  constructor(private service: SharedService) { }

  WeatherList: any = [];

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList() {
    this.service.getWeather().subscribe(data => {
      this.WeatherList = data;
    });
  }

}
