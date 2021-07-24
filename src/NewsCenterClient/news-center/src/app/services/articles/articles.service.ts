import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ICreateArticle } from '../../models/ICreateArticle';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  private createPath = environment.apiUrl + 'admin/articles/create';

  constructor(private http: HttpClient) { }

  create(data: ICreateArticle) : Observable<ICreateArticle> {
    return this.http.post<ICreateArticle>(this.createPath, data);
  }
}
