import { Component, Injectable } from '@angular/core';  
 
import { HttpClient } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Person } from '../model/employe.model';
import { Service } from '../services/service';
  
@Injectable({  
  providedIn: 'root'  
})  
@Component({  selector: 'app-customer',
templateUrl: './customer.component.html',
styleUrls: ['./customer.component.scss'],})
export class Customer {  


  constructor(private http: HttpClient,
    private service: Service) { }  
//   AllUserDetails(): Observable<User[]> {  
//     return this.http.get<User[]>(this.url + 'Api/UserAPI/AllUser')  
//   }  

onSave(){

  let person: Person = {
    name: 'Jane',
    age: '25',
    address: 'demo',
    ticketId: '1'
  };
  this.service.postCustomer(person).subscribe((response) =>{
    console.log(response)
  })
}
} 