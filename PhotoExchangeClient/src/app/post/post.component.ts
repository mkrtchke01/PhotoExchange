import { Component, OnInit } from '@angular/core';
import { Post } from '../shared/models/post';
import { PostService } from '../shared/services/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  constructor(private service: PostService) { }


  postList: Post[];


  ngOnInit(): void {
    this.getPostList();
  }

  getPostList(){
    this.service.getList().subscribe(data=>{
      this.postList = data;
    })
  }

}
