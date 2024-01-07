import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from '../_models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  // baseUrl = 'http://localhost:5159/api/';
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCustomers(){
    return this.http.get<Customer[]>(this.baseUrl + 'customer');
  }

  getCustomer(customerNumber:string){
    return this.http.get<Customer>(this.baseUrl + 'customer/' + customerNumber);
  }
}
