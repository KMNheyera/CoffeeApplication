import { NgModule, Pipe, PipeTransform } from '@angular/core';
import { map } from 'rxjs/operators';
import { IPointsSettings } from '../interfaces/points';
import { ServiceService } from '../service/service.service';


@Pipe({
  name: 'pointsconversion'
})
export class PointsConversionPipe implements PipeTransform {
  constructor(
    private symService : ServiceService
  ){
  }
  transform(value: any): any{
   return this.symService.GetPointsSettings().pipe(map((pointsSettings:IPointsSettings)=>{
     let result: string = "";

     let cashValue = value*pointsSettings.PointsRate



      return this.toCurrency("R", cashValue);
    }))
  }
  toCurrency(currency: any, value: any): string {
      let result: string = "";
            result = `${currency} ${value.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, " ")}`;
      if(currency == "none"){
        result = value.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, " ");
      }
      return result;
    }
}



@NgModule({
  imports: [],
  declarations: [PointsConversionPipe],
  exports: [PointsConversionPipe]
})

export class PointsConversionModule { }
