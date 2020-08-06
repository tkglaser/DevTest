import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { shareReplay } from "rxjs/operators";
import { CustomerModel } from "../models/customer.model";
import { CustomerService } from "../services/customer.service";

@Component({
  selector: "app-customer",
  templateUrl: "./customer.component.html",
  styleUrls: ["./customer.component.scss"],
})
export class CustomerComponent implements OnInit {
  public customers$: Observable<CustomerModel[]>;

  constructor(private readonly customerService: CustomerService) {}

  ngOnInit() {
    this.customers$ = this.customerService
      .GetCustomers()
      .pipe(shareReplay({ bufferSize: 1, refCount: true }));
  }
}
