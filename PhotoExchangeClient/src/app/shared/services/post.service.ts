import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  readonly apiUrl = 'https://localhost:7242/api/Post'


  getList() : Observable<any>{
      return this.http.get(this.apiUrl);
  }
  getUserPosts() : Observable<any>{
    return this.http.get(this.apiUrl + '/GetUserPosts');
}

  
}
