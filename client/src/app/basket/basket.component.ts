import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasektItem, IBasket } from '../shared/models/basket.interface';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss'],
})
export class BasketComponent implements OnInit {
  basket$!: Observable<IBasket | null>;
  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }

  increment(item: IBasektItem) {
    console.log('increment');

    this.basketService.icrementItemInBasket(item);
  }

  decrement(item: IBasektItem) {
    this.basketService.decrementItemInBasket(item);
  }

  removeItem(item: IBasektItem) {
    this.basketService.removeItemFromBasket(item);
  }
}
