import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { PagingComponent } from './components/paging/paging.component';

@NgModule({
  declarations: [PagingHeaderComponent, PagingComponent],
  imports: [CommonModule, NgbPaginationModule],
  exports: [PagingHeaderComponent, PagingComponent],
})
export class SharedModule {}
