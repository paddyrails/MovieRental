import {Routes, RouterModule} from "@angular/router";
import { MovieSelectionComponent } from "./store/movie-selection/movie-selection.component";

const routes: Routes = [
    
    { path: "Store", component: MovieSelectionComponent},
    { path: "", component: MovieSelectionComponent},
]

export const RoutingConfig = RouterModule.forRoot(routes);