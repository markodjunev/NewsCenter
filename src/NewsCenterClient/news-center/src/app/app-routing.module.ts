import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateArticleComponent } from './admin/create-article/create-article.component';
import { AllCategoriesComponent } from './categories/all-categories/all-categories.component';
import { LoginComponent } from './users/login/login.component';
import { RegisterComponent } from './users/register/register.component';
import { AuthGuardService } from './services/auth/auth-guard.service';
import { AdminAuthGuardService } from './services/auth/admin-auth-guard.service';
import { EditArticleComponent } from './admin/edit-article/edit-article.component';
import { CategoryDetailsComponent } from './categories/category-details/category-details.component';
import { ArticleDetailsComponent } from './articles/article-details/article-details.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: AllCategoriesComponent },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'admin/articles/create', component: CreateArticleComponent, canActivate: [AdminAuthGuardService]},
  { path: 'admin/articles/edit/:id', component: EditArticleComponent, canActivate: [AdminAuthGuardService]},
  { path: 'categories/:id', component: CategoryDetailsComponent},
  { path: 'articles/:id', component: ArticleDetailsComponent, canActivate: [AuthGuardService]},
  { path: 'error', component: NotFoundComponent},
  {path: '**', redirectTo: 'error'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
