import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/shared/models/post';
import { Profile } from 'src/app/shared/models/profile';
import { AuthService } from 'src/app/shared/services/auth.service';
import { PostService } from 'src/app/shared/services/post.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private authService: AuthService, private postService: PostService) { }

  profile: Profile = new Profile;
  userPostList: Post[];

  ngOnInit(): void {
   this.getProfile();
   this.getUserPosts();
  }

  getProfile(){
    this.authService.getProfile().subscribe(data=>{
      this.profile = data;
    })
  }
  getUserPosts(){
    this.postService.getUserPosts().subscribe(data=>{
      this.userPostList = data;
      console.log(data);
    })
  }
}
