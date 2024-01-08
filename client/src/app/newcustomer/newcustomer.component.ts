import { Component, OnInit } from '@angular/core';
import { FormGroup , FormControl, Validators, FormBuilder} from '@angular/forms';
import { CustomerService } from '../_services/customer.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-newcustomer',
  templateUrl: './newcustomer.component.html',
  styleUrls: ['./newcustomer.component.css']
})
export class NewcustomerComponent implements OnInit{
  newCustomerForm: FormGroup = new FormGroup({});

  constructor(private customerService: CustomerService, private toastr: ToastrService, 
    private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.newCustomerForm = new FormGroup({
       name: new FormControl('', Validators.required),
       customerNumber: new FormControl('', [Validators.required, Validators.minLength(2),Validators.maxLength(9)]),
       city: new FormControl('', Validators.required),
       street: new FormControl('', Validators.required),
       fullName: new FormControl('', Validators.required),
       officeNumber: new FormControl(''),
       email: new FormControl('', Validators.email)
    })
  }

  cancel(){
    this.router.navigateByUrl('/customers');
  }

  insertCustomer() {
    this.customerService.insertNewCustomer(this.newCustomerForm.value).subscribe({
      next: response => {
        this.router.navigateByUrl('/customers');
      },
      error: error => this.toastr.error(error.error)
    })
  }
}
