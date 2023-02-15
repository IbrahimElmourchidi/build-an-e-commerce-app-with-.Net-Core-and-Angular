import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastComponent } from './toast/toast.component';

@NgModule({
  declarations: [
    NavBarComponent,
    TestErrorComponent,
    NotfoundComponent,
    ServerErrorComponent,
    ToastComponent,
  ],
  imports: [CommonModule, RouterModule],
  exports: [NavBarComponent, ToastComponent],
})
export class CoreModule {}
