import { Injectable } from '@angular/core';
import { MovieSelectionComponent } from '../store/movie-selection/movie-selection.component';

@Injectable()
export class Cart {
    selections: MovieSelection[] = [];
    itemCount: number = 0;
    totalPrice: number = 0;

    addMovie(movie: Movie) {
        let selection = this.selections
            .find(ps => ps.movieId == movie.movieId);
        if(selection){
            selection.quantity++;
        }else{
            this.selections.push(new MovieSelection(this, movie.movieId, movie.name, movie.price, 1));
        }
        this.update();
    }
}


export class MovieSelection {
    constructor(public cart: Cart,
        public movieId?: number,
        public name?: string,
        public price?: number,
        private quantityValue?: number){}
    get quantity (){
        return this.quantityValue;
    }
    set quantity(newQuantity: number)
}