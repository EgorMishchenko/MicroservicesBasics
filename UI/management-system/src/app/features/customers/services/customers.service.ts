import { Injectable } from '@angular/core';
import { AddCustomerRequest } from '../models/add-customer-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private http: HttpClient) { }

  addCustomer(model: AddCustomerRequest):Observable<void>{
    return this.http.post<void>(`https://localhost:5000/api/customers`, model);
  }

  getAllCustomers(): Observable<Customer[]>{
     return this.http.get<Customer[]>(`https://localhost:5000/api/customers`);
  }
}
