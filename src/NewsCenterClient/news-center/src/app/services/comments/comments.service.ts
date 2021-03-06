import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateComment } from 'src/app/models/comments/ICreateComment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  private createPath = environment.apiUrl + 'comments/create';
  private deletePath = environment.apiUrl + 'comments/delete';

  constructor(private http: HttpClient) { }

  create(data: ICreateComment): Observable<ICreateComment> {
    return this.http.post<ICreateComment>(this.createPath, data);
  }

  delete(id: number) {
    return this.http.delete(this.deletePath + '/' + id);
  }
}
