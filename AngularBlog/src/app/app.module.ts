import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule, Router } from "@angular/router";
import { appRoutes } from "./routes";
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { CityComponent } from "./city/city.component";
import {CityAddComponent} from "./city-add/city-add.component"
import {AlertifyService} from './services/alertify.service';
@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      CityComponent,     
      CityAddComponent      
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes),
      AppRoutingModule,
      FormsModule, ReactiveFormsModule    
   ],
  providers: [AlertifyService],
  bootstrap: [AppComponent]
})
export class AppModule {}
