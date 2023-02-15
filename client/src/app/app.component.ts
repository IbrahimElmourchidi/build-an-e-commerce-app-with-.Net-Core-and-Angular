import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IErrorResponse } from './shared/models/error-response.interface';
import { IPagination } from './shared/models/pagination.interface';
import { IProduct } from './shared/models/product.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'skinet';

  constructor() {}
  ngOnInit(): void {}
}
