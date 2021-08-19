import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ArticleDetailsComponent } from './article-details/article-details.component';

@NgModule({
    declarations: [
    ArticleDetailsComponent
  ],
    imports: [
      CommonModule,
      RouterModule,
    ]
  })
  export class ArticlesModule { }