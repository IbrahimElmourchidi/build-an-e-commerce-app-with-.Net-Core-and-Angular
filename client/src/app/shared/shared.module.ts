import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { PagingComponent } from './components/paging/paging.component';
import { OrderSummaryComponent } from './components/order-summary/order-summary.component';

@NgModule({
  declarations: [PagingHeaderComponent, PagingComponent, OrderSummaryComponent],
  imports: [CommonModule, NgbPaginationModule],
  exports: [PagingHeaderComponent, PagingComponent, OrderSummaryComponent],
})
export class SharedModule {}
