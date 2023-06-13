import { Injectable } from '@angular/core';
import {NgbModal, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from '../modals/login/login.component';
import { PayCoffeeComponent } from '../modals/pay-coffee/pay-coffee.component';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(
    private modalService: NgbModal
  ) { }
    openDialogPayment(props: any): Promise<any> {
      var modalRef = this.modalService.open(PayCoffeeComponent, {size: 'lg', backdrop: 'static'});
      modalRef.componentInstance.setDialogProps(props);

      // return modalRef.result

      return new Promise(resolve => {
        resolve(modalRef.result);
      })
    }

    openDialogLogin(props: any): Promise<any> {
      var modalRef = this.modalService.open(LoginComponent, {size: 'lg', backdrop: 'static'});
      modalRef.componentInstance.setDialogProps(props);
      return new Promise(resolve => {
        resolve(modalRef.result);
      })
    }
}

