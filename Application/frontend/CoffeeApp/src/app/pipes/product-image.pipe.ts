import { NgModule, Pipe, PipeTransform } from '@angular/core';
import { map } from 'rxjs/operators';


@Pipe({
  name: 'productimage'
})
export class ProductImagePipe implements PipeTransform {
  constructor(
  ){

  }
  transform(value: any): any{
    return this.readBlob(value)
  }
  readBlob(content: string, contentType: string = 'image/jpg'): string {
    return `data:${contentType};base64,${content}`;
  }
}


@NgModule({
  imports: [],
  declarations: [ProductImagePipe],
  exports: [ProductImagePipe]
})

export class ProductImageModule { }
