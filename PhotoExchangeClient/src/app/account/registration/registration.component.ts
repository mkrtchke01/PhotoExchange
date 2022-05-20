import { Component, OnInit } from '@angular/core';
import { Register } from 'src/app/shared/models/register';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerModel: Register = new Register;


  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  register(){
    this.accountService.register(this.registerModel);
    console.log(this.registerModel);
  }

}
