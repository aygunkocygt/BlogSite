import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
//import {AlertifyService} from '';
import {City} from '../city/city';
import {Router} from '@angular/router';
import {AlertifyService} from './alertify.service';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private httpClient:HttpClient,
              private router:Router,
              private alertifyService:AlertifyService) { }

              path="http://localhost:2890/api/";

              getCities():Observable<City[]>{
                return this.httpClient.get<City[]>(this.path+"city");
              }
              getCityById(cityId):Observable<City>{
              return this.httpClient.get<City>(this.path+"city/"+cityId)
            }
            add(city){
              this.httpClient.post(this.path+'city',city).subscribe(data=>{
                this.alertifyService.success("Basarıyla Eklendi")
              });
            }
      }

