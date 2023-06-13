import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ServiceService } from '../../service/service.service';
import { IUser } from '../../interfaces/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  title: string = 'Login';
  password:string= "password!23"
  email:string= ""
  firstName:string= "";
  lastName:string= "";

  isFailedLoginAttempt: boolean = false;


  constructor(
    public modal: NgbActiveModal,
    private symService : ServiceService
  ) { }

  ngOnInit(): void {
  }

  setDialogProps(properties: any){
    this.title = properties.title
    // console.log('properties', properties)
   }

   signUp(){
    let result: string = 'failed'
    let user: IUser = {
      Id: "",
      FirstName: this.firstName,
      LastName: this.lastName,
      Email: this.email,

    }
    if(this.email.trim() != ""){
      this.symService.AddUser(user).subscribe((user:IUser)=>{
        if(user){
          result = 'success'
          localStorage.setItem('userId', user.Id);
          this.modal.close(result);
        }
        this.isFailedLoginAttempt = true
      })
    }
   }

  signIn(){
    let result: string = 'failed'
    if(this.email.trim() != ""){
      this.symService.SignIn(this.email).subscribe((user:IUser)=>{
        if(user){
          result = 'success'
          localStorage.setItem('userId', user.Id);
          this.modal.close(result);
        }
        this.isFailedLoginAttempt = true
      })
    }
  }

}
