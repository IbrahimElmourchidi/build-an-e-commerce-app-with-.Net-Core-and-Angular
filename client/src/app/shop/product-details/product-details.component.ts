import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IErrorResponse } from 'src/app/shared/models/error-response.interface';
import { IProduct } from 'src/app/shared/models/product.interface';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  productId!: number;
  product!: IProduct;
  quantityToAdd = 1;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shopService: ShopService,
    private bcService: BreadcrumbService,
    private basketService: BasketService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.productId = parseInt(params.get('id') as string);
      if (isNaN(this.productId)) this.router.navigate(['/', 'shop']);
    });
    this.shopService.GetSingleProduct(this.productId).subscribe({
      next: (prod: IProduct) => {
        this.product = prod;
        this.bcService.set('@productDetails', prod.name);
      },
      error: (err: IErrorResponse) => console.log(err),
    });
  }

  increment() {
    this.quantityToAdd++;
  }

  decrement() {
    this.quantityToAdd = --this.quantityToAdd > 0 ? this.quantityToAdd : 0;
  }

  addToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantityToAdd);
  }
}
