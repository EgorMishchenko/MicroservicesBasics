import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListComponent } from './features/customers/customer-list/customer-list.component'
import { AddCustomerComponent } from './features/customers/customer/add-customer/add-customer.component'

const routes: Routes = [
  {
    path: 'admin/customers',
    component: CustomerListComponent
  },
  {
    path: 'admin/add-customer',
    component: AddCustomerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
