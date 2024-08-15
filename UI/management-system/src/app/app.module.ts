import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { CustomerListComponent } from './features/customers/customer-list/customer-list.component';
import { AddCustomerComponent } from './features/customers/customer/add-customer/add-customer.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './features/auth/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CustomerListComponent,
    AddCustomerComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
