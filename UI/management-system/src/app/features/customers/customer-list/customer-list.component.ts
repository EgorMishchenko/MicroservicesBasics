import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model'
import { CustomersService } from '../services/customers.service'

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  customers$: Observable<Customer[]>;

  constructor(private customerService: CustomersService) { }

  ngOnInit() {
    this.customers$ = this.customerService.getAllCustomers();
  }

}
