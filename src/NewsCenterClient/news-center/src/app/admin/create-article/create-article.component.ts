import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ICategoryDropDown } from '../../models/ICategoryDropDown';
import { ICreateArticle } from '../../models/ICreateArticle';
import { ArticlesService } from '../../services/articles/articles.service';
import { CategoriesService } from '../../services/categories/categories.service';

@Component({
  selector: 'app-create-article',
  templateUrl: './create-article.component.html',
  styleUrls: ['./create-article.component.css']
})
export class CreateArticleComponent implements OnInit {
  createArticleForm: FormGroup;
  categories: Array<ICategoryDropDown>
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private toastrService: ToastrService,
    private categoriesService: CategoriesService,
    private articlesService: ArticlesService
  ) {
    this.createArticleForm = this.fb.group({
      'title': ['', [Validators.required]],
      'imageUrl': ['', [Validators.required]],
      'content': ['', [Validators.required]],
      'categoryId': ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
    this.categoriesService.getDropDownModels().subscribe(data =>
      this.categories = data);
  }

  create() {
    if (this.createArticleForm.invalid) {
      return;
    }

    this.toastrService.info('Creating an article...');

    const article: ICreateArticle = Object.assign({}, this.createArticleForm.value);

    this.articlesService.create(article).subscribe(data => {
      console.log(data);
      this.toastrService.clear();
      this.toastrService.success("You've created an article successfully!");
      this.router.navigate(["/"]);
    })
  }

  get title() {
    return this.createArticleForm.get('title');
  }

  get imageUrl() {
    return this.createArticleForm.get('imageUrl');
  }

  get content() {
    return this.createArticleForm.get('content');
  }

  get categoryId() {
    return this.createArticleForm.get('categoryId');
  }
}