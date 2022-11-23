import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CreatePostRequest } from 'src/app/shared/models/create-post-request';
import { PostService } from 'src/app/shared/services/post.service';

import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {

  constructor(private postService: PostService, private router: Router,  public dialogRef: MatDialogRef<CreatePostComponent>) { }

  createPostRequest: CreatePostRequest = new CreatePostRequest()
  isImage: boolean = false
  getImageObject: any
  image: string

  ngOnInit(): void {
  }


  onSelected(event:any){
    
    this.createPostRequest.photo = event.target.files[0]
    this.imageHandler()
    this.isImage = true
    console.log(this.createPostRequest.photo)
  }

  uploadPost(){
    this.postService.uploadPost(this.createPostRequest).subscribe(()=>{
      this.router.navigate(['/profile'])
    })
  }
  imageHandler(){
    this.postService.imageHandler(this.createPostRequest.photo).subscribe(data=>{
      this.getImageObject = data
      this.image = 'data:image/png;base64,' + this.getImageObject.image
    })
  }

  cancelClick(): void {
    this.dialogRef.close()
  }

}
