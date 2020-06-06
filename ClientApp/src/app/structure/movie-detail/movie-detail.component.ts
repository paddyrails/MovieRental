import { Component, OnInit } from '@angular/core';
import { Movie } from '../../models/movie.model';
import { Repository } from '../../models/repository';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  
  constructor(private repo: Repository, 
      private router: Router, 
      private activeRoute: ActivatedRoute) 
  {         
    let id = Number.parseInt(activeRoute.snapshot.params["id"]);
    if(id){
      this.repo.getMovie(id);
    }else{
      router.navigateByUrl("/");
    }
  }

  ngOnInit() {
  }

  get movie(): Movie {
    return this.repo.movie;
  }

}
