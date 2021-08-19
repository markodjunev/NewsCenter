import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LikeCommentsService {
  private likePath = environment.apiUrl + 'likeComments/create';
  private dislikePath = environment.apiUrl + 'likeComments/delete';


  constructor(private http: HttpClient) { }

  like(id: number) {
    return this.http.post(this.likePath + '/' + id, null);
  }

  dislike(id: number) {
    return this.http.delete(this.dislikePath + '/' + id);
  }
}
