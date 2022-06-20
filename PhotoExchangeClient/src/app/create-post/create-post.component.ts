import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CreatePostDto } from '../shared/models/createPostDto';
import { PostService } from '../shared/services/post.service';

import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {

  constructor(private postService: PostService, private router: Router,  public dialogRef: MatDialogRef<CreatePostComponent>) { }

  createPostDto: CreatePostDto = new CreatePostDto();
  isImage: boolean = false;
  getImageObject: any;
  image: string;

  ngOnInit(): void {
  }


  onSelected(event:any){
    
    this.createPostDto.photo = event.target.files[0];
    this.imageHandler();
    this.isImage = true;
    console.log(this.createPostDto.photo);
  }

  uploadPost(){
    this.postService.uploadPost(this.createPostDto).subscribe(data=>{
      this.router.navigate(['/profile']);
    });
  }
  imageHandler(){
    this.postService.imageHandler(this.createPostDto.photo).subscribe(data=>{
      this.getImageObject = data;
      this.image = 'data:image/png;base64,' + this.getImageObject.image;
    });
  }

  cancelClick(): void {
    this.dialogRef.close();
  }

}
