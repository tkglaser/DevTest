import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { shareReplay } from "rxjs/operators";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

import { CustomerModel } from "../models/customer.model";
import { CustomerService } from "../services/customer.service";

@Component({
  selector: "app-customer",
  templateUrl: "./customer.component.html",
  styleUrls: ["./customer.component.scss"],
})
export class CustomerComponent implements OnInit {
  public customers$: Observable<CustomerModel[]>;
  public createForm: FormGroup;

  constructor(
    private readonly customerService: CustomerService,
    private readonly fb: FormBuilder
  ) {}

  ngOnInit() {
    this.createForm = this.fb.group({
      name: this.fb.control("", [Validators.required, Validators.minLength(5)]),
      type: "Small",
    });
    this.fetchCustomers();
  }

  createCustomer() {
    if (this.createForm.invalid) {
      alert('form is not valid');
    } else {
      this.customerService
        .CreateCustomer(this.createForm.value)
        .subscribe(() => this.fetchCustomers());
    }
  }

  private fetchCustomers() {
    this.customers$ = this.customerService
      .GetCustomers()
      .pipe(shareReplay({ bufferSize: 1, refCount: true }));
  }
}
