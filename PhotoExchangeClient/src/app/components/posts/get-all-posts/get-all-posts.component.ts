import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/shared/models/post';
import { PostService } from 'src/app/shared/services/post.service';
import { SignalrService } from 'src/app/shared/services/signalr.service';


@Component({
  selector: 'app-get-all-posts',
  templateUrl: './get-all-posts.component.html',
  styleUrls: ['./get-all-posts.component.css']
})
export class GetAllPostsComponent implements OnInit {

  constructor(private postService: PostService, private signalRService: SignalrService) { }

  postList: Post[]


  ngOnInit(): void {
    this.signalRService.GetConnection()
    this.signalRService.askServerListener()
    this.getPostList()
  }

  
  private LikeUp(userName: string, postId: number){
    this.signalRService.LikeHubServer(userName, postId)
  }
  getPostList(userName: string = "", postId: number = 0){
    if(userName == "" || postId == 0){
      this.postService.getList().subscribe(data=>{
        this.postList = data
      })
    }
    else{
      this.LikeUp(userName, postId)
      setTimeout(() => {
        this.postService.getList().subscribe(data=>{
          this.postList = data
        })
      }, 10)
    }
  }
  ngOnDestroy(){
    this.signalRService.hubConnection.off("askServerResponse")
  }

}
