import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AllCategoriesComponent } from './all-categories/all-categories.component';
import { CategoryDetailsComponent } from './category-details/category-details.component';

@NgModule({
  declarations: [
    AllCategoriesComponent,
    CategoryDetailsComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
  ]
})
export class CategoriesModule { }