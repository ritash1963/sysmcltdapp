import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from '../_models/customer';
import { CustomerForInsert } from '../_models/customerForInsert';
import { CustomerForUpdate } from '../_models/customerForUpdate';
import { Address } from '../_models/address';
import { Contact } from '../_models/contact';

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

  insertNewCustomer(customerForInsert:CustomerForInsert){
    return this.http.post(this.baseUrl + 'customer/insertNewCustomer', customerForInsert);
  }

  updateCustomer(customerForUpdate:CustomerForUpdate)  {
    return this.http.put(this.baseUrl + 'customer/UpdateCustomer', customerForUpdate);
  }

  deleteCustomer(customerNumber:string)  {
    return this.http.delete(this.baseUrl + 'customer/DeleteCustomer/' + customerNumber);
  }

  getAddresses(customerNumber:string){
     return this.http.get<Address[]>(this.baseUrl + 'customer/getAddresses/' + customerNumber);
  }

  getContacts(customerNumber:string){
    return this.http.get<Contact[]>(this.baseUrl + 'customer/getContacts/' + customerNumber);
 }

}
