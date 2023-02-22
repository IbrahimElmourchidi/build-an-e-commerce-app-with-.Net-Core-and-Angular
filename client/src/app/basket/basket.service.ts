import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment as env } from 'src/environments/environment';
import {
  Basket,
  IBasektItem,
  IBasket,
  IBasketTotals,
} from '../shared/models/basket.interface';
import { IProduct } from '../shared/models/product.interface';
@Injectable({
  providedIn: 'root',
})
export class BasketService {
  private basketSource = new BehaviorSubject<IBasket | null>(null);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals | null>(null);
  basketTotal$ = this.basketTotalSource.asObservable();

  constructor(private http: HttpClient) {}

  getBasket(id: string) {
    return this.http
      .get<IBasket>(env.apiUrl + 'basket', {
        params: { id },
      })
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.calculateTotal();
        })
      );
  }

  setBasket(basket: IBasket) {
    console.log('lets set the basket');
    return this.http.post<IBasket>(env.apiUrl + 'basket', basket).subscribe({
      next: (res) => {
        this.basketSource.next(res);
        this.calculateTotal();
      },
      error: (err) => console.log(err),
    });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct, quantity = 1) {
    const itemToAdd: IBasektItem = this.mapproductItemToBasketitem(
      item,
      quantity
    );
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    this.addItem(basket, itemToAdd);
    this.setBasket(basket);
  }

  decrementItemInBasket(item: IBasektItem) {
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    let foundIndex = basket.items.findIndex((el) => el.id == item.id);
    if (foundIndex != -1) {
      basket.items[foundIndex].quantity--;
      if (basket.items[foundIndex].quantity < 1)
        basket.items.splice(foundIndex, 1);
    }
    this.setBasket(basket);
  }

  icrementItemInBasket(item: IBasektItem) {
    const basket = this.getCurrentBasketValue();
    if (basket) {
      let foundIndex = basket.items.findIndex((el) => el.id == item.id);
      if (foundIndex != -1) {
        basket.items[foundIndex].quantity++;
      }
      this.setBasket(basket);
    }
  }

  removeItemFromBasket(item: IBasektItem) {
    const basket = this.getCurrentBasketValue();
    if (basket) {
      let foundIndex = basket.items.findIndex((el) => el.id == item.id);
      if (foundIndex != -1) {
        basket.items.splice(foundIndex, 1);
      }
      this.setBasket(basket);
    }
  }

  private calculateTotal() {
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket!.items.reduce(
      (a, b) => a + b.price * b.quantity,
      0
    );
    const total = subtotal + shipping;
    this.basketTotalSource.next({ shipping, subtotal, total });
  }

  private addItem(basket: IBasket, item: IBasektItem) {
    let foundIndex = basket.items.findIndex((el) => el.id == item.id);
    if (foundIndex == -1) {
      basket.items.push(item);
    } else basket.items[foundIndex].quantity += item.quantity;
  }

  private createBasket(): Basket {
    const basket = new Basket();
    localStorage.setItem('basketId', basket.id);
    return basket;
  }

  mapproductItemToBasketitem(item: IProduct, quantity: number): IBasektItem {
    const newBasketItem: IBasektItem = {
      id: item.id,
      price: item.price,
      quantity,
      brand: item.productBrand,
      pictureUrl: item.pictureUrl,
      productName: item.name,
      type: item.productType,
    };
    return newBasketItem;
  }
}
