import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateArticleComponent } from './create-article/create-article.component';
import { RouterModule } from '@angular/router';
import { EditArticleComponent } from './edit-article/edit-article.component';

@NgModule({
    declarations: [   
    CreateArticleComponent, 
    EditArticleComponent
  ],
    imports: [
      CommonModule,
      RouterModule,
      ReactiveFormsModule
    ]
  })
  export class AdminModule { }