import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ICategoryDropDown } from '../../models/categories/ICategoryDropDown';
import { IEditArticle } from '../../models/articles/IEditArticle';
import { IUpdateArticle } from '../../models/articles/IUpdateArticle';
import { ArticlesService } from '../../services/articles/articles.service';
import { CategoriesService } from '../../services/categories/categories.service';

@Component({
  selector: 'app-edit-article',
  templateUrl: './edit-article.component.html',
  styleUrls: ['./edit-article.component.css']
})
export class EditArticleComponent implements OnInit {
  editArticleForm: FormGroup;
  categories: Array<ICategoryDropDown>;
  article: IUpdateArticle;
  id: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private toastrService: ToastrService,
    private categoriesService: CategoriesService,
    private articlesService: ArticlesService
  ) {
    this.editArticleForm = this.fb.group({
      'title': ['', [Validators.required]],
      'imageUrl': ['', [Validators.required]],
      'content': ['', [Validators.required]],
      'categoryId': ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.categoriesService.getDropDownModels().subscribe(data => {
      this.categories = data;
    });

    this.articlesService.getUpdateModel(this.id).subscribe(res => {
      this.article = res;
      this.editArticleForm = this.fb.group({
        'title': [this.article.title, [Validators.required]],
        'imageUrl': [this.article.imageUrl, [Validators.required]],
        'content': [this.article.content, [Validators.required]],
        'categoryId': [this.article.categoryId, [Validators.required]],
      });
    });

  }

  edit() {
    if (this.editArticleForm.invalid) {
      return;
    }

    this.toastrService.info('Edit article...');

    const editedArticle: IEditArticle = Object.assign({}, this.editArticleForm.value);

    this.articlesService.edit(this.id, editedArticle).subscribe(data => {
      console.log(data);
      this.toastrService.clear();
      this.toastrService.success("You've edited the article successfully!");
      this.router.navigate(["/articles/" + this.id]);
    })
  }

  get title() {
    return this.editArticleForm.get('title');
  }

  get imageUrl() {
    return this.editArticleForm.get('imageUrl');
  }

  get content() {
    return this.editArticleForm.get('content');
  }

  get categoryId() {
    return this.editArticleForm.get('categoryId');
  }
}
