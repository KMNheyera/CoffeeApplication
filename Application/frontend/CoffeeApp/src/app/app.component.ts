import { Component, ViewChild } from '@angular/core';
import { ServiceService } from './service/service.service';
import {  IProduct} from './interfaces/product';
import { Observable } from 'rxjs';
import { ICart } from './interfaces/cart';
// import { PayCoffeeComponent } from './modals/pay-coffee/pay-coffee.component';
import { DialogService } from './service/dialog.service';
import { IUser } from './interfaces/user';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'CoffeeApplication';

  // @ViewChild("payCoffee") coffeeModal!: PayCoffeeComponent;
  users$: Observable<IUser[]>;

  products$: Observable<IProduct[]>;
  cart: ICart[] = [];
  totalPrice: number = 0;
  cartEmpty: boolean = true;
  payed: boolean = false;
  signedIn: boolean = false;

  constructor(
    private symService: ServiceService,
    private dialogService: DialogService
  ) {
    console.log('Hello AppComponent');
    this.products$ = this.symService.GetProducts()
    this.users$ = this.symService.GetUsers()

}

   showModal() {
     let dialogRef = this.dialogService.openDialogPayment({
      title: "Pay Coffee",
      data: this.cart,
      totalCost: this.totalPrice
    });

    dialogRef.then((result: any) => {

      this.payed = true;
    });
  }

  calculateTotalPrice() {
    this.totalPrice = 0;
    this.cart.forEach(x => {
      this.totalPrice += x.Price * x.Qty;
    })
    if (this.cart.length > 0) {
      this.cartEmpty = false;
    }
  }

  addToCart(product: IProduct) {
    console.log('product', product);
    let cartItem: ICart = {
      Id: product.Id,
      ProductName:  product.ProductName,
      Price: product.Price,
      Qty:  1
    }
    this.cart.push(cartItem);
    console.log('cart', this.cart);
    this.calculateTotalPrice()
  }
  checkCart(product: IProduct) : boolean {
    let result: boolean = false;
    let cartItem: ICart | undefined = this.cart.find(x => x.Id == product.Id);

    if (cartItem != undefined) {
      result = true;
    }

    return result;
  }

  incrementQty(id:string){
    let cartItem: ICart | undefined = this.cart.find(x => x.Id == id);
    if (cartItem != undefined) {
      cartItem.Qty++;
    }
    this.calculateTotalPrice()
  }
  decrementQty(id:string){
    let cartItem: ICart | undefined = this.cart.find(x => x.Id == id);
    if (cartItem != undefined && cartItem.Qty > 1) {
      cartItem.Qty--;
    }
    this.calculateTotalPrice()
  }
  removeItem(id: string): void {
    this.cart = this.cart.filter(x => x.Id != id);
    this.calculateTotalPrice()
  }

  shopAgain() {
    this.cart = [];
    this.totalPrice = 0;
    this.cartEmpty = true;
    this.payed = false;
  }
}
