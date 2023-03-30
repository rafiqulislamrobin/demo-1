import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Customer } from './Features/Employee/customer.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path:'customer',
    component: Customer,
  },
  {
    path:'home',
    component: HomeComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
