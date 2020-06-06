import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CartSummaryComponent } from './cart-summary/cart-summary.component';
import { CategoryFilterComponent } from './category-filter/category-filter.component';
import { MovieListComponent } from './movie-list/movie-list.component';
import { MovieSelectionComponent } from './movie-selection/movie-selection.component';
import { PaginationComponent } from './pagination/pagination.component';
import { RatingsComponent } from './ratings/ratings.component';
import { MovieTableComponent } from '../structure/movie-table/movie-table.component';

@NgModule({
  declarations: [
    CartSummaryComponent, CategoryFilterComponent, MovieListComponent,
    MovieSelectionComponent, PaginationComponent, RatingsComponent, MovieTableComponent
  ],
  imports: [    
    BrowserModule
  ],
  providers: [],
  exports: [MovieSelectionComponent]  
})

export class StoreModule { }
