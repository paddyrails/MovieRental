import { Component, OnInit } from '@angular/core';
import { Repository } from '../../models/repository';

@Component({
  selector: 'app-category-filter',
  templateUrl: './category-filter.component.html',
  styleUrls: ['./category-filter.component.css']
})
export class CategoryFilterComponent implements OnInit {
  
  constructor(private repo: Repository) { }

  ngOnInit() {
  }
  get categories() : string[]{
    return this.repo.categories;
  }

  get currentCategory(): string {
    return this.repo.filter.category;
  }

  setCurrentCategory(category: string){
    this.repo.filter.category = category;
    this.repo.getMovies();
  }

}
