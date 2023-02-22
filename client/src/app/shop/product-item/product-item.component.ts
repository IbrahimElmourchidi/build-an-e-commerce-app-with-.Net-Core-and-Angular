import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product.interface';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss'],
})
export class ProductItemComponent implements OnInit {
  @Input('product') product!: IProduct;
  constructor(private basketService: BasketService) {}

  ngOnInit(): void {}

  addItemToBasket() {
    console.log('add', this.product);

    this.basketService.addItemToBasket(this.product);
  }
}
