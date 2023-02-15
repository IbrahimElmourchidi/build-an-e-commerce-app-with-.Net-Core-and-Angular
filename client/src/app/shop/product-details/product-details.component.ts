import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IErrorResponse } from 'src/app/shared/models/error-response.interface';
import { IProduct } from 'src/app/shared/models/product.interface';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  productId!: number;
  product!: IProduct;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shopService: ShopService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.productId = parseInt(params.get('id') as string);
      if (isNaN(this.productId)) this.router.navigate(['/', 'shop']);
    });
    this.shopService.GetSingleProduct(this.productId).subscribe({
      next: (prod: IProduct) => {
        this.product = prod;
      },
      error: (err: IErrorResponse) => console.log(err),
    });
  }
}
