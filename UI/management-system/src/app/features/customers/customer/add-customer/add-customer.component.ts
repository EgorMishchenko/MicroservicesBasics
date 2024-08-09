import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddCustomerRequest } from '../../models/add-customer-request.model';
import { CustomersService } from '../../services/customers.service'
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnDestroy {

  model: AddCustomerRequest;
  private addCustomerSubscription?: Subscription;

  constructor(private customersService: CustomersService) {
    this.model = {
      firstname: 'Ivan',
      lastname: 'Invanov',
      birthday: '21/02/2000',
      email: 'youngboy@ggmail.com ',
      address: 'USA, Maryland, Annapolis, Central St., 32123',
    }
  }
  ngOnDestroy(): void {
    this.addCustomerSubscription.unsubscribe;
  }

  onCustomerCreate() {
    this.customersService.addCustomer(this.model)
    .subscribe({
      next:(response) => {
        console.log('This was successful')
      },
      error: (err) => {
        console.log(err)
      }
    });
    
  }

}
