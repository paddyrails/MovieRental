import { Movie } from './movie.model';
import { HttpClient } from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';
import { Filter } from './configClasses.repository';
import { moveEmbeddedView } from '@angular/core/src/view';
import { Studio } from './studio.model';

const moviesUrl = "/api/movies";
const studiosUrl = "/api/studios";

@Injectable()
export class Repository {

    private filterObject = new Filter();

    constructor(private http: HttpClient){
        //this.filter.category = "drama";
        this.filter.related = true;
        this.getMovies();
        //this.getMovie(2);
    }

    getMovies(related = false){
        let url = moviesUrl + "?related=" + this.filter.related;
        if(this.filter.category){
            url += "&category=" + this.filter.category;
        }
        if(this.filter.search){
            url += "&search=" + this.filter.search;
        }

        this.http
            .get<Movie[]>(url)
            .subscribe(result => {
                this.movies = result;
            },
            error => console.error(error)
            );
    }

    getMovie(id: number) {
        console.log("movie Data Requested");
        this.http.get(moviesUrl + "/" + id)
            .subscribe(response => {
                console.log(response);
                this.movie = response
            });
    }

    getStudios(){
        this.http.get<Studio[]>(studiosUrl)
        .subscribe(response => this.studios = response);
    }

    createMovie(mov: Movie){
        let data = {
            //Image:mov.image, 
            name: mov.name,
            category: mov.category,
            description: mov.description,
            price: mov.price,
            studio: mov.studio ? mov.studio.studioId : 0
        };
        this.http.post<number>(moviesUrl, data)
        .subscribe(response => {
            mov.movieId = response;
            this.movies.push(mov);
        })
    }

    creatMovieAndStudio(mov: Movie, stu: Studio){
        let data = {
            name: stu.name, city: stu.city, state:stu.state
        };
        this.http.post<number>(studiosUrl, data)
        .subscribe(response => {
            stu.studioId = response;
            this.studios.push(stu);
            if(mov != null){
                this.createMovie(mov);
            }
        })
    }

    replaceMovie(mov: Movie){
        let data = {
            //Image:mov.image, 
            name: mov.name,
            category: mov.category,
            description: mov.description,
            price: mov.price,
            studio: mov.studio ? mov.studio.studioId : 0
        };
        this.http.put(moviesUrl+"/"+mov.movieId, data)
            .subscribe(response => this.getMovies());
    }

    replaceStudio(stu: Studio){
        let data = {
            name: stu.name, city: stu.city, state:stu.state
        };
        this.http.put(studiosUrl+"/"+stu.studioId,data)
            .subscribe(response => this.getStudios());
    }
    

    movie : Movie;
    movies : Movie[];
    studios : Studio[] = [];
    get filter(): Filter {
        return this.filterObject;
    }
}