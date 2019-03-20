import { Component, OnInit } from '@angular/core';
import  { City } from '../city/city';
import  {HttpClient} from '@angular/common/http';
import {CityService} from '../services/city.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css'],
  providers:[CityService]
})
export class CityComponent implements OnInit {

  constructor(private http:HttpClient,
    private cityService:CityService) { }
  cities:City[];

  ngOnInit() {
    this.cityService.getCities().subscribe(data =>{
      this.cities=data;
    })
  }

}
