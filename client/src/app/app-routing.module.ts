import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { NewcustomerComponent } from './newcustomer/newcustomer.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'customers', component: CustomerListComponent},
  {path: 'customers/:customerNumber', component: CustomerDetailComponent},
  {path: 'newcustomer', component: NewcustomerComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
