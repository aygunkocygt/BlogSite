import { Injectable } from '@angular/core';
import {LoginUser} from '../models/loginUser';
import {HttpHeaders,HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {AlertifyService} from '../services/alertify.service';
import {RegisterUser} from '../models/registerUser';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpClient,
    private router:Router,
    private alertifyService:AlertifyService
    ) { }

    path="http://localhost:2890/api/";

    login(loginUser:LoginUser){
      let headers = new HttpHeaders();
      headers = headers.append("Content-Type","application/json");
      this.httpClient
      .get(this.path+"user?username="+loginUser.userName + "&password=" + loginUser.password, {headers:headers})
      .subscribe(data  => {
        if(data['UserRole'] == "admin"){
          this.router.navigateByUrl("/cityadd");
        }
        else{
          this.router.navigateByUrl("/city");
          //buraa kullanıcların gidecegi sayfa
        }
      });
    }
/*
    register(registerUser:RegisterUser){
      let headers = new HttpHeaders();
      headers = headers.append("Content-Type","application/json");
      this.httpClient.post(this.path+"register",registerUser,{headers:headers})
       .subscribe(data => {
        

       });
    }
*/
}
