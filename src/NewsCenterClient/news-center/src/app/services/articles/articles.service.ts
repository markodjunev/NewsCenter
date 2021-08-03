import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ICreateArticle } from '../../models/ICreateArticle';
import { IUpdateArticle } from '../../models/IUpdateArticle';
import { IEditArticle } from '../../models/IEditArticle';
import { ICategoryDetails } from '../../models/ICategoryDetails';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  private createPath = environment.apiUrl + 'admin/articles/create';
  private getUpdateModelPath = environment.apiUrl + 'admin/articles/updatemodel';
  private editPath = environment.apiUrl + 'admin/articles/edit';
  private byCategoryPath = environment.apiUrl + 'articles/bycategory';

  constructor(private http: HttpClient) { }

  create(data: ICreateArticle) : Observable<ICreateArticle> {
    return this.http.post<ICreateArticle>(this.createPath, data);
  }

  getUpdateModel(id: number) : Observable<IUpdateArticle>{
    return this.http.get<IUpdateArticle>(this.getUpdateModelPath + '/' + id)
  }

  edit(id: number, data: IEditArticle) : Observable<IEditArticle> {
    return this.http.put<IEditArticle>(this.editPath + '/' + id, data);
  }

  byCategory(id: number, page: number) : Observable<ICategoryDetails> {
    const params = new HttpParams()
    .set('page', page);

    return this.http.get<ICategoryDetails>(this.byCategoryPath + '/' + id, {params});
  }
}
