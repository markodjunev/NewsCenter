import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService } from './services/auth/auth.service';
import { SharedModule } from './shared/shared.module';
import { UsersModule } from './users/users.module';
import { CategoriesModule } from './categories/categories.module';
import { AdminModule } from './admin/admin.module';
import { AuthGuardService } from './services/auth/auth-guard.service';
import { AdminAuthGuardService } from './services/auth/admin-auth-guard.service';
import { TokenInterceptorService } from './services/token/token-interceptor.service';
import { ErrorInterceptorService } from './services/error/error-interceptor.service';
import { ArticlesService } from './services/articles/articles.service';
import { CategoriesService } from './services/categories/categories.service';
import { ArticlesModule } from './articles/articles.module';
import { LikeCommentsService } from './services/likeComments/like-comments.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    UsersModule,
    CategoriesModule,
    AdminModule,
    ArticlesModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    ArticlesService,
    CategoriesService,
    AuthService,
    AuthGuardService,
    AdminAuthGuardService,
    LikeCommentsService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
