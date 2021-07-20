import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { ICategory } from '../../models/ICategory';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private allCategoriesPath = environment.apiUrl + 'categories/all';

  constructor(private http: HttpClient, private router: Router) { }

  getAll(): Observable<Array<ICategory>> {
    return this.http.get<Array<ICategory>>(this.allCategoriesPath);
  }
}
