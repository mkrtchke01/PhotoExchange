import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/services/auth.service';

import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CreatePostComponent } from '../create-post/create-post.component';





@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router, public authService: AuthService, public dialog: MatDialog) { }

  formModal: any;


  ngOnInit(): void {
  }

  logoutClick(){
    this.router.navigate(['/login']);
  }

  openCreatePostDialog(): void {
    const dialogRef = this.dialog.open(CreatePostComponent, {
      width: '50%',
      height: '80%'
    });
    dialogRef.afterClosed().subscribe();
  }

}
