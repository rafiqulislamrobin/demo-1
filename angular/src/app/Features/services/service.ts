import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Person, postResponse, } from '../model/employe.model';

@Injectable ({providedIn: 'root'})
export class Service {
     url = "https://localhost:7063/api/Demo";
     
     constructor(
        private httpClient: HttpClient
     ){

     }
     postCustomer (customer: Person){
        console.log(customer)
        return this.httpClient.post<postResponse>(
            this.url,
            customer
        );
     }
}