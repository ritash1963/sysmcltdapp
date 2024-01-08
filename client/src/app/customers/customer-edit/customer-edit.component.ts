import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/_models/customer';
import { CustomerService } from 'src/app/_services/customer.service';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent {
  customer: Customer | undefined;
  @ViewChild('editForm') editForm: NgForm | undefined;

  constructor(private customerService: CustomerService, private route: ActivatedRoute,
                private router: Router, private toastr: ToastrService, ) {} 

    ngOnInit(): void {
      this.loadCustomer();
    }

  loadCustomer(){
    var customerNumber = this.route.snapshot.paramMap.get('customerNumber');
    if (!customerNumber) return;
    this.customerService.getCustomer(customerNumber).subscribe({
        next:customer => {
          this.customer = customer}
    })
  }
  
  updateCustomer(){
    // console.log(this.editForm?.value);
    this.customerService.updateCustomer(this.editForm?.value).subscribe({
      next: _ => {
        this.toastr.success('Profile updated successfully');
        this.editForm?.reset(this.customer);
      }
    })
  }

  cancel(){
    this.router.navigateByUrl('/customers');
  }
}
