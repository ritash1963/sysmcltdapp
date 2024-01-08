import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/_models/customer';
import { CustomerService } from 'src/app/_services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit{
   customers: Customer[] = [];

   constructor(private customerService: CustomerService, private toastr: ToastrService){}

   ngOnInit(): void{
      this.loadCustomers();
   }

   loadCustomers(){
      this.customerService.getCustomers().subscribe({
        next: customers => this.customers = customers
      })
   }

   deleteCustomer(customerNumber:string){
      // console.log(customerNumber + ' customerNumber');
      this.customerService.deleteCustomer(customerNumber).subscribe({
         next: _ => {
            this.toastr.success('Customer deleted successfully');
            this.loadCustomers();
       }
       });
   }
}
