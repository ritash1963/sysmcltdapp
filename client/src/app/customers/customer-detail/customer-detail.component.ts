import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Address } from 'src/app/_models/address';
import { Contact } from 'src/app/_models/contact';
import { Customer } from 'src/app/_models/customer';
import { CustomerService } from 'src/app/_services/customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit{
   customer: Customer | undefined;
   addresses: Address[] | undefined;
   contacts: Contact[] | undefined;

   constructor(private customerService: CustomerService, private route: ActivatedRoute) {} 

    ngOnInit(): void {
      this.loadCustomer();
      this.loadAddresses();
      this.loadContacts();
  }

  loadCustomer(){
    var customerNumber = this.route.snapshot.paramMap.get('customerNumber');
    if (!customerNumber) return;
    this.customerService.getCustomer(customerNumber).subscribe({
        next:customer => {
          this.customer = customer}
    })
  }
  
  loadAddresses(){
    var customerNumber = this.route.snapshot.paramMap.get('customerNumber');
    if (!customerNumber) return;
    this.customerService.getAddresses(customerNumber).subscribe({
        next:addresses => {
          this.addresses = addresses}
    })
  }

  loadContacts(){
    var customerNumber = this.route.snapshot.paramMap.get('customerNumber');
    if (!customerNumber) return;
    this.customerService.getContacts(customerNumber).subscribe({
        next:contacts => {
          this.contacts = contacts}
    })
  }


}
