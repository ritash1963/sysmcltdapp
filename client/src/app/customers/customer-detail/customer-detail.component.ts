import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/_models/customer';
import { CustomerService } from 'src/app/_services/customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit{
   customer: Customer | undefined

   constructor(private customerService: CustomerService, private route: ActivatedRoute) {} 

    ngOnInit(): void {
      this.loadCustomer();
  }

  loadCustomer(){
    var customerNumber = this.route.snapshot.paramMap.get('customerNumber');
    if (!customerNumber) return;
    this.customerService.getCustomer(customerNumber).subscribe({
        next:customer => this.customer = customer
    })
  }

}
