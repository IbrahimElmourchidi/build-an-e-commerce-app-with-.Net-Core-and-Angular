import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotfoundComponent } from './core/notfound/notfound.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    data: { breadcrumb: 'Home' },
  },
  {
    path: 'error',
    component: TestErrorComponent,
    data: { breadcrumb: 'Test Errors' },
  },

  {
    path: 'notfound',
    component: NotfoundComponent,
    data: { breadcrumb: '404' },
  },

  {
    path: 'servererror',
    component: ServerErrorComponent,
    data: { breadcrumb: 'Server Error' },
  },

  {
    path: 'shop',
    loadChildren: () => import('./shop/shop.module').then((m) => m.ShopModule),
    data: { breadcrumb: 'shop' }
  },
  {
    path:'basket',
    loadChildren: ()=> import('./basket/basket.module').then(m=> m.BasketModule),
    data: {breadcrumb: 'basket'}
  },
  {
    path: '**',
    redirectTo: 'notfound',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
