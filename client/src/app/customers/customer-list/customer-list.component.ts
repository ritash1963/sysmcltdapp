import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/_models/customer';
import { CustomerService } from 'src/app/_services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit{
   customers: Customer[] = [];

   constructor(private customerService: CustomerService){}

   ngOnInit(): void{
      this.loadCustomers();
   }

   loadCustomers(){
      this.customerService.getCustomers().subscribe({
        next: customers => this.customers = customers
      })
   }
}
