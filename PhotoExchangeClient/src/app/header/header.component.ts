import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router) { }

  isAuthorithed: boolean = false;

  ngOnInit(): void {
  }

  checkIsAuthorithed(){
    var currentUser = JSON.parse(localStorage.getItem('currentUser') || '');
    if(currentUser.token == ''){
      this.isAuthorithed = true;
    }
    else this.isAuthorithed= false;
  }

  logoutClick(){
    localStorage.clear();
    this.isAuthorithed = false;
    this.router.navigate(['/login']).then(()=>window.location.reload());
  }

}
