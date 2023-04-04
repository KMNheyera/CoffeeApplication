import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { ProductImageModule } from './pipes/product-image.pipe';
import { CurrencyModule } from './pipes/currency.pipe';
import { HeaderComponent } from './components/header/header.component';
import { PayCoffeeComponent } from './modals/pay-coffee/pay-coffee.component';
import { FormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { LoginComponent } from './modals/login/login.component';
import { UsernameModule } from './pipes/username.pipe';
import { PointsConversionModule } from './pipes/points-conversion.pipe';
// import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    PayCoffeeComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    ProductImageModule,
    CurrencyModule,
    FormsModule,
    UsernameModule,
    PointsConversionModule,
    TabsModule.forRoot()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
