import { Component, OnInit } from '@angular/core';
import { DialogService } from 'src/app/service/dialog.service';
import { ServiceService } from 'src/app/service/service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  title = "Coffee Application"
  signedIn: boolean = false;
  userId: any;
  constructor(
    private dialogService: DialogService,
    private symService : ServiceService
  ) { }

  ngOnInit(): void {
    localStorage.getItem('userId') ? this.signedIn = true : this.signedIn = false;
    if(this.signedIn){
      this.userId = localStorage.getItem('userId');
    }
  }

  signIn() {
    let dialogRef = this.dialogService.openDialogLogin({
      title: "Sign In",
    });

    dialogRef.then((result: any) => {
      this.userId = localStorage.getItem('userId');
      this.signedIn = true;
    });
  }

  signOut() {
    localStorage.removeItem('userId');
    this.signedIn = false;
  }
}
