import { CityComponent } from "./city/city.component";
import {Routes} from "@angular/router";
import { CityAddComponent } from "./city-add/city-add.component";



export const appRoutes : Routes = [
  { path: "city", component: CityComponent },
  { path: "cityadd", component: CityAddComponent }, 
  { path: "**", redirectTo: "city", pathMatch: "full" }
];

