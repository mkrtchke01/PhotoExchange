import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreatePostRequest } from '../models/create-post-request';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  readonly apiUrl = 'https://localhost:7242/api/Post'


  getList() : Observable<any>{
      return this.http.get(this.apiUrl)
  }
  getUserPosts() : Observable<any>{
    return this.http.get(this.apiUrl + '/GetUserPosts')
  }

  uploadPost(model: CreatePostRequest){
    console.log(model)
    const formData = new FormData()
    formData.append('Photo', model.photo)
    formData.append('Text', model.text)
    return this.http.post(this.apiUrl + '/UploadPost', formData)
  }

  imageHandler(image: File){
    const formData = new FormData()
    formData.append('Image', image)
    return this.http.post(this.apiUrl + '/ImageHandler', formData)
  }
  
}
