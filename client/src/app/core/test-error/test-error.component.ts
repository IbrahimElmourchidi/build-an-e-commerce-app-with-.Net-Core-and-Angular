import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product.interface';
import { environment as env } from 'src/environments/environment';
@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss'],
})
export class TestErrorComponent implements OnInit {
  validationErrors: string[] = [];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  get404() {
    this.http.get<IProduct>(env.apiUrl + 'product/42').subscribe({
      next: (product) => console.log(product),
      error: (err) => console.log(err),
    });
  }

  get500() {
    this.http.get<IProduct>(env.apiUrl + 'buggy/servererror').subscribe({
      next: (product) => console.log(product),
      error: (err) => console.log(err),
    });
  }

  get400() {
    this.http.get<IProduct>(env.apiUrl + 'buggy/badrequest').subscribe({
      next: (product) => console.log(product),
      error: (err) => {
        console.log(err);
      },
    });
  }

  get400Validation() {
    this.http.get<IProduct>(env.apiUrl + 'product/two').subscribe({
      next: (product) => console.log(product),
      error: (err) => {
        console.log(err);
        this.validationErrors = err.errors;
      },
    });
  }
}
