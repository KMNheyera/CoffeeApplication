import { NgModule, Pipe, PipeTransform } from '@angular/core';
import { map } from 'rxjs/operators';
import { IUser } from '../interfaces/user';
import { ServiceService } from '../service/service.service';


@Pipe({
  name: 'username'
})
export class UsernamePipe implements PipeTransform {
  constructor(
    private symService : ServiceService
  ){
  }
  transform(value: any): any{
    return this.symService.GetUser(value).pipe(map((user:IUser)=>{
      return `${user.FirstName} ${user.LastName} (${user.PointsEarned} Points)`
    }))
  }
}



@NgModule({
  imports: [],
  declarations: [UsernamePipe],
  exports: [UsernamePipe]
})

export class UsernameModule { }
