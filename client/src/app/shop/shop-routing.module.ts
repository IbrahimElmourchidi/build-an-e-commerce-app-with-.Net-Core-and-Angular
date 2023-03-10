import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

let shopRoutes: Routes = [
  {
    path: '',
    component: ShopComponent,
  },
  {
    path: ':id',
    component: ProductDetailsComponent,
    data: { breadcrumb: { alias: 'productDetails' } },
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(shopRoutes)],
  exports: [RouterModule],
})
export class ShopRoutingModule {}
