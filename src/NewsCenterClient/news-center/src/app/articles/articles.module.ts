import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { RouterModule } from '@angular/router';
import { ArticleDetailsComponent } from './article-details/article-details.component';

@NgModule({
  declarations: [
    ArticleDetailsComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatDialogModule
  ]
})
export class ArticlesModule { }