import { NgModule, Pipe, PipeTransform } from '@angular/core';
import { map } from 'rxjs/operators';


@Pipe({
  name: 'currency'
})
export class CurrencyPipe implements PipeTransform {
  constructor(
  ){
  }
  transform(value: any): any{
    return this.toCurrency("R",value)
  }
  toCurrency(currency: any, value: any): string {
      let result: string = "";
      // if(currency == "ZAR"){
      //   currency = "R"
      // }

      result = `${currency} ${value.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, " ")}`;
      if(currency == "none"){
        result = value.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, " ");
      }
      return result;
    }
}



@NgModule({
  imports: [],
  declarations: [CurrencyPipe],
  exports: [CurrencyPipe]
})

export class CurrencyModule { }
