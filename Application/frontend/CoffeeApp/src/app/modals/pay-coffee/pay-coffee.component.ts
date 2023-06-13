import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ICart } from 'src/app/interfaces/cart';
import { IPayment } from 'src/app/interfaces/payment';
// import { ToastrService } from 'ngx-toastr';
import { IProduct } from 'src/app/interfaces/product';
import { ServiceService } from 'src/app/service/service.service';

@Component({
  selector: 'app-pay-coffee',
  templateUrl: './pay-coffee.component.html',
  styleUrls: ['./pay-coffee.component.scss']
})
export class PayCoffeeComponent implements OnInit {
  @Input() modalData: any;
  title: any;
  products: ICart [] = [];
  totalCost: any;
  readonly cardData = {
    cardNumber: '1234567812345678',
    expirationDate: '2023-06',
    cvv: '123',
    cardholderName: 'John Doe',
    billingAddress: '123 Main St.'
  };

  signedIn: boolean = false;
  userId: string | null= '';

  payment: IPayment = {} as IPayment;

 constructor(
   public modal: NgbActiveModal,
   private symService : ServiceService
 ) { }
  ngOnInit(): void {
    localStorage.getItem('userId') ? this.signedIn = true : this.signedIn = false;
    if(this.signedIn){
      this.userId = localStorage.getItem('userId');
    }
  }

   setDialogProps(properties: any){
    this.title = properties.title
    this.products = properties.data
    this.totalCost = properties.totalCost


   }

    pay() {

    this.payment = {
     UserId: this.userId,
      Products: this.products,
    }
      let result: string = 'failed'
      if(this.signedIn){
        this.symService.Payment(this.payment).subscribe((user:any)=>{
          if(user){
            result = 'success'
            this.modal.close(result);
          }
        })
      this.modal.close(result);
    }
  }
}
