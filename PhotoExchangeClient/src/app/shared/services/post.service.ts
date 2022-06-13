import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreatePostDto } from '../models/createPostDto';

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

  uploadPost(model: CreatePostDto){
    console.log(model);
    const formData = new FormData();
    formData.append('Photo', model.photo);
    formData.append('Text', model.text);
    return this.http.post(this.apiUrl + '/UploadPost', formData);
  }

  imageHandler(image: File){
    const formData = new FormData();
    formData.append('Image', image)
    return this.http.post(this.apiUrl + '/ImageHandler', formData);
  }
  
}
