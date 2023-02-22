import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { BusyService } from './core/services/busy.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'skinet';

  constructor(
    private busyService: BusyService,
    private basketService: BasketService
  ) {}

  ngOnInit(): void {
    let storedBasketId = localStorage.getItem('basketId');
    if (storedBasketId) {
      this.basketService.getBasket(storedBasketId).subscribe({
        next: (res) => {
          console.log('initialized basket');
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }
}
