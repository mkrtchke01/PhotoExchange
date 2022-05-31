import { Component, OnDestroy, OnInit } from '@angular/core';
import { Post } from '../shared/models/post';
import { PostService } from '../shared/services/post.service';
import { SignalRService } from '../shared/signal-r.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit, OnDestroy {

  constructor(private service: PostService, private signalRService: SignalRService) { }


  postList: Post[];


  ngOnInit(): void {
    this.signalRService.GetConnection();
    this.signalRService.askServerListener();
    this.getPostList();
  }

  
  private LikeUp(userName: string, postId: number){
    this.signalRService.LikeHubServer(userName, postId);
  }
  getPostList(userName: string = "", postId: number = 0){
    if(userName == "" || postId == 0){
      this.service.getList().subscribe(data=>{
        this.postList = data;
      })
    }
    else{
      this.LikeUp(userName, postId);
      setTimeout(() => {
        this.service.getList().subscribe(data=>{
          this.postList = data;
        })
      }, 10);
    }
  }
  ngOnDestroy(){
    this.signalRService.hubConnection.off("askServerResponse");
  }

}
