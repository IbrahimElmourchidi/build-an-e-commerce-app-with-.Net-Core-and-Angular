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
  },
  {
    path: 'error',
    component: TestErrorComponent,
  },

  {
    path: 'notfound',
    component: NotfoundComponent,
  },

  {
    path: 'servererror',
    component: ServerErrorComponent,
  },

  {
    path: 'shop',
    loadChildren: () => import('./shop/shop.module').then((m) => m.ShopModule),
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
