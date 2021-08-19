import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICategory } from '../../models/categories/ICategory';
import { CategoriesService } from '../../services/categories/categories.service';

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
  styleUrls: ['./all-categories.component.css']
})
export class AllCategoriesComponent implements OnInit {
  categories: Array<ICategory>

  constructor(private categoriesService: CategoriesService, private router: Router) { }

  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories(){
    this.categoriesService.getAll().subscribe(categories =>{
      this.categories = categories;
      console.log(categories);
    })
  }
}
