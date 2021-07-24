import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ICategory } from '../../models/ICategory';
import { ICategoryDropDown } from '../../models/ICategoryDropDown';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private allCategoriesPath = environment.apiUrl + 'categories/all';
  private categoriesDropDownPath = environment.apiUrl + 'admin/categories/dropdown';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<ICategory>> {
    return this.http.get<Array<ICategory>>(this.allCategoriesPath);
  }

  getDropDownModels(): Observable<Array<ICategoryDropDown>> {
    return this.http.get<Array<ICategoryDropDown>>(this.categoriesDropDownPath);
  }
}
