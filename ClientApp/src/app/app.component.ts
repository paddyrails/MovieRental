import { Component } from '@angular/core';
import { Repository } from './models/repository';
import { Movie } from './models/movie.model';
import { Studio } from './models/studio.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  constructor(private repo: Repository){    
  }
  get movie():Movie{
    return this.repo.movie;
  }

  get movies(): Movie[]{
    return this.repo.movies;
  }

  createMovie(){
    this.repo.createMovie(new Movie(0,"X-Men Final Chapter", 
    "Drama", "After the re-emergence of the world's first mutant, " +
    "the world-destroyer Apocalypse, the X-Men must unite to defeat his " +
    "extinction level plan.",49.99, this.repo.movies[0].studio))
  }
  createMovieAndStudio(){
    let s = new Studio(0,"SkyTaylor Films", "Brooklyn","NY");
    let m = new Movie(0, "Chef", "Romance",
    "A head chef quits his restaurant job and buys a food truck", 100, s);
    this.repo.creatMovieAndStudio(m, s);
  }
}
