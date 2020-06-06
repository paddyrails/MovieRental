import { Component, OnInit } from '@angular/core';
import { Repository } from '../../models/repository';
import { Movie } from '../../models/movie.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-table',
  templateUrl: './movie-table.component.html',
  styleUrls: ['./movie-table.component.css']
})
export class MovieTableComponent implements OnInit {

  constructor(private repo: Repository, private router: Router) { }

  ngOnInit() {
  }

  get movies() : Movie[]{
    return this.repo.movies;
  }

  // selectMovie(id:number){
  //   this.repo.getMovie(id);
  //   this.router.navigateByUrl("/detail/"+id);
  // }
}
